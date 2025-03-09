using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.InvoiceDTOs;
using ECommerce.Shared.DTOs.OrderDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.Extensions;
using Fluid.Values;
using Fluid;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class OrderService : IOrderService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBasketService basketService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IInvoiceService ınvoiceService;
        private readonly IEmailService emailService;


        public OrderService(IBasketService basketService, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IInvoiceService ınvoiceService, IEmailService emailService)
        {
            this.basketService = basketService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            this.ınvoiceService = ınvoiceService;
            this.emailService = emailService;

        }

        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> CreateOrderAsync(OrderCreateDTO orderCreateDTO)
        {

            var basketResponse = await basketService.GetBasketAsync();



            var basketDTO = basketResponse.Data;
            if (basketDTO == null || !basketDTO.BasketItems.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail { Message = "Basket is empty.", Code = "BASKET_EMPTY", Target = "Basket" }
        }, HttpStatusCode.BadRequest);
            }

            var user = await _unitOfWork.GetRepository<ApplicationUser>()
                .GetAsync(u => u.Id == orderCreateDTO.ApplicationUserId);

            if (user == null)
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail(new List<ErrorDetail>
                      {
                        new ErrorDetail { Message = "User not found.", Code = "USER_NOT_FOUND", Target = "User" }
                    }, HttpStatusCode.NotFound);
            }

            if (basketDTO.BasketItems.Any(item => !item.Product.IsActive))
            {

                return ResponseDTO<IEnumerable<OrderDTO>>.Fail(new List<ErrorDetail>
                      {
                        new ErrorDetail { Message = "product is not active.", Code = "PRODUCT_ISNT_ACTIVE", Target = "Product" }
                    }, HttpStatusCode.NotFound);

            }




            var groupedBySeller = basketDTO.BasketItems
                 .GroupBy(item => item.Product.ApplicationUserId)
                 .Where(group => group.Key != null)
                 .ToList();
            List<Order> createdOrders = new List<Order>();
            List<InvoiceDTO> createdInvoice = new List<InvoiceDTO>();
            foreach (var seller in groupedBySeller)
            {
                Console.WriteLine($"Seller ID: {seller.Key}");

                decimal orderTotalAmount = 0;

                var order = new Order
                {
                    ApplicationUserId = orderCreateDTO.ApplicationUserId,
                    OrderDate = DateTime.Now,
                    Status = OrderStatus.Hazırlanıyor,
                    TotalPrice = 0,
                    OrderItems = new List<OrderItem>()
                };

                foreach (var basketItem in seller)
                {
                    var product = basketItem.Product;

                    var basketItemDTO = basketDTO.BasketItems.FirstOrDefault(bi =>
               bi.ProductId == basketItem.ProductId &&
               bi.Size.Id == basketItem.Size.Id &&
               bi.Color.Id == basketItem.Color.Id
               );
                    if (basketItemDTO != null)
                    {
                        decimal itemTotalPrice = basketItemDTO.DiscountedPrice * basketItem.Quantity;


                        var orderItem = new OrderItem
                        {
                            ProductId = basketItem.ProductId,
                            Quantity = basketItem.Quantity,


                            TotalPrice = itemTotalPrice,
                            Size = (ProductSize)basketItem.Size.Id,
                            Color = (ProductColor)basketItem.Color.Id,
                        };

                        orderTotalAmount += itemTotalPrice;
                        order.OrderItems.Add(orderItem);
                    }

                }

                order.TotalPrice = orderTotalAmount;
                order.OrderNumber = GenerateOrderNumber();
                order.Status = OrderStatus.Hazırlanıyor;


                await _unitOfWork.GetRepository<Order>().AddAsync(order);
                await _unitOfWork.SaveChangesAsync();
                var products = order.OrderItems.Select(oi => oi.Product).ToList();

                foreach (var product in products)
                {
                    product.Stock -= order.OrderItems.FirstOrDefault(oi => oi.ProductId == product.Id).Quantity;
                    if (product.Stock < 0)
                    {
                        product.Stock = 0;
                    }
                    _unitOfWork.GetRepository<Product>().UpdateAsync(product);
                }

                await _unitOfWork.SaveChangesAsync();



                var invoice = await ınvoiceService.CreateInvoiceAsync(new InvoiceCreateDTO
                {
                    Address = user.Address,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    OrderId = order.Id
                });

                createdOrders.Add(order);
                createdInvoice.Add(invoice.Data);
            }

            await SendOrderMailAsync(createdOrders);

            foreach (var invoice in createdInvoice)
            {
                await SendInvoiceMail(invoice);
            }
            await basketService.ClearBasketAsync();

            return ResponseDTO<IEnumerable<OrderDTO>>.Success(_mapper.Map<List<OrderDTO>>(createdOrders), HttpStatusCode.Created);
        }






        private async Task SendOrderMailAsync(IEnumerable<Order> orders)
        {
            string subject = "Siparişiniz Alınmıştır!";

            try
            {

                var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "OrderMailTemplate.liquid");

                if (!File.Exists(templatePath))
                {
                    throw new FileNotFoundException($"Şablon dosyası bulunamadı: {templatePath}");
                }

                var templateText = await File.ReadAllTextAsync(templatePath);

                var parser = new FluidParser();
                if (!parser.TryParse(templateText, out var template, out var error))
                {
                    throw new InvalidOperationException("Şablon ayrıştırma hatası: " + error);
                }

                var templateContext = new TemplateContext();

                var orderList = new List<Dictionary<string, object>>();

                foreach (var order in orders)
                {
                    var orderItems = new List<Dictionary<string, object>>();

                    foreach (var orderItem in order.OrderItems)
                    {

                        orderItems.Add(new Dictionary<string, object>
                      {
                           { "Name", orderItem.Product.Name },
                          { "ImageUrl",  orderItem.Product.ImageUrl},
                          { "Quantity", orderItem.Quantity },
                        { "UnitPrice", orderItem.TotalPrice / orderItem.Quantity },
                          { "TotalPrice", orderItem.TotalPrice },
                            { "Size", orderItem.Size.GetDisplayName() },
                         { "Color", orderItem.Color.GetDisplayName() },
                           });
                    }

                    var orderData = new Dictionary<string, object>
                      {
                       { "OrderNumber", order.OrderNumber },
                        { "OrderItems", orderItems },
                        { "TotalPrice", order.TotalPrice }
                         };

                    orderList.Add(orderData);
                }

                templateContext.SetValue("orders", orderList);

                var body = template.Render(templateContext);


                await emailService.SendEmailAsync(orders.First().ApplicationUser.Email, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
                throw;
            }
        }

        private async Task SendInvoiceMail(InvoiceDTO invoice)
        {
            string subject = "Faturanız Oluşturulmuştur!";
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "InvoiceMailTemplate.liquid");

            if (!File.Exists(templatePath))
            {
                Console.WriteLine($"Şablon dosyası bulunamadı: {templatePath}");
                return;
            }

            try
            {
                var templateText = await File.ReadAllTextAsync(templatePath);
                var parser = new FluidParser();

                if (!parser.TryParse(templateText, out var template, out var error))
                {
                    throw new InvalidOperationException("Şablon ayrıştırma hatası: " + error);
                }

                var templateContext = new TemplateContext();
                var orderItemsList = invoice.Order.OrderItems.Select(orderItem => new Dictionary<string, object>
        {
            { "Name", orderItem.Product.Name },
            { "Quantity", orderItem.Quantity },
            { "TotalPrice", orderItem.TotalPrice },
            { "UnitPrice", orderItem.TotalPrice / orderItem.Quantity },
           { "Size", ((ProductSize)orderItem.Size.Id).GetDisplayName() },
           { "Color", ((ProductColor)orderItem.Color.Id).GetDisplayName() }

        }).ToList();

                var invoiceData = new Dictionary<string, object>
        {
            { "InvoiceNumber", invoice.InvoiceNumber },
            { "OrderItems", orderItemsList },
            { "TotalPrice", invoice.TotalPrice }
        };

                templateContext.SetValue("invoice", invoiceData);
                var body = template.Render(templateContext);

                await emailService.SendEmailAsync(invoice.Order.ApplicationUserName, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
            }
        }


        private string GenerateOrderNumber(int length = 10)
        {
            var random = RandomNumberGenerator.Create();
            var bytes = new byte[length];
            random.GetNonZeroBytes(bytes);

            var result = BitConverter.ToInt32(bytes, 0);
            return Math.Abs(result).ToString();

        }



        public async Task<ResponseDTO<NoContent>> DeleteOrderAsync(int id)
        {
            var order = await _unitOfWork.GetRepository<Order>().GetAsync(x => x.Id == id);
            if (order == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail
                {
                    Message = "Order not found",
                    Code = "NOT_FOUND",
                    Target = "order"
                }
            }, HttpStatusCode.NotFound);
            }
            order.IsDeleted = true;
            _unitOfWork.GetRepository<Order>().SoftDeleteAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }
        public async Task<ResponseDTO<OrderDTO>> GetOrderAsync(int id)
        {
            var order = await _unitOfWork.GetRepository<Order>().GetAsync(x => x.Id == id, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).Include(o => o.ApplicationUser)); 
          
            if (order == null)
            {
                return ResponseDTO<OrderDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Order not found",
                Code = "NOT_FOUND",
                Target = "order"
            }
        }, HttpStatusCode.NotFound);
            }

            var orderDTO = _mapper.Map<OrderDTO>(order);

         
            orderDTO.ApplicationUserAdress = order.ApplicationUser?.Address;

          

            var response = ResponseDTO<OrderDTO>.Success(orderDTO, HttpStatusCode.OK);
        

            return response;
        }



        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync()
        {
            var orders = await _unitOfWork.GetRepository<Order>().GetAllAsync();
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Orders not found",
                Code = "NOT_FOUND",
                Target = "orders"
            }
        }, HttpStatusCode.NotFound);
            }

            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, HttpStatusCode.OK);
        }




        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(OrderStatus orderStatus)
        {
            var orders = await _unitOfWork.GetRepository<Order>().GetAllAsync(x => x.Status == orderStatus, null, null, true, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Orders not found",
                        Code = "NOT_FOUND",
                        Target = "orders"
                    }
                    }, HttpStatusCode.NotFound);


            }

            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(string applicationUserId)
        {
            var orders = await _unitOfWork.GetRepository<Order>().GetAllAsync(x => x.ApplicationUserId == applicationUserId, null, null, true, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Orders not found",
                        Code = "NOT_FOUND",
                        Target = "orders"
                    }
                    }, HttpStatusCode.NotFound);
            }

            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, HttpStatusCode.OK);

        }

        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(DateTime startDate, DateTime endDate)
        {
            var orders = await _unitOfWork.GetRepository<Order>().GetAllAsync(x => x.OrderDate >= startDate && x.OrderDate <= endDate, null, null, true, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Orders not found",
                        Code = "NOT_FOUND",
                        Target = "orders"
                    }
                    }, HttpStatusCode.NotFound);
            }

            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, HttpStatusCode.OK);
        }


        public async Task<ResponseDTO<NoContent>> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO)
        {

            var order = await _unitOfWork.GetRepository<Order>().GetAsync(x => x.Id == orderUpdateDTO.Id, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));

            if (order == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {

                    new ErrorDetail
                    {
                        Message = "Orders not found",
                        Code = "NOT_FOUND",
                        Target = "orders"
                    }
                    }, HttpStatusCode.NotFound);
            }

            order.OrderItems.Clear();
            _unitOfWork.GetRepository<Order>().UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            order.OrderItems = orderUpdateDTO.OrderItems.Select(oi => new OrderItem
            {
                Id = oi.Id,
                UpdatedAt = DateTime.Now,
                Quantity = oi.Quantity


            }).ToList();

            _unitOfWork.GetRepository<Order>().UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersBySellerIdAsync(string sellerId)
        {
            var orders = await _unitOfWork.GetRepository<Order>()
        .GetAllAsync(
            x => x.OrderItems.Any(oi => oi.Product.ApplicationUserId == sellerId),
            null,
            null,
            true,
            query => query
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
        );

            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Orders not found",
                Code = "NOT_FOUND",
                Target = "orders"
            }
        }, HttpStatusCode.NotFound);
            }


            var filteredOrders = orders
                .Where(order => order.OrderItems
                    .Any(orderItem => orderItem.Product.ApplicationUserId == sellerId))
                .ToList();

            if (!filteredOrders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "No orders found for this seller",
                Code = "NOT_FOUND",
                Target = "orders"
            }
        }, HttpStatusCode.NotFound);
            }


            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(filteredOrders);

            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, HttpStatusCode.OK);
        }
        public async Task<ResponseDTO<NoContent>> UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus)
        {
            var order = await _unitOfWork.GetRepository<Order>().GetAsync(x=>x.Id==orderId, query=>query.Include(x=>x.Invoice));
            if (order == null)
            {
                return ResponseDTO<NoContent>.Fail("Sipariş bulunamadı!", HttpStatusCode.NotFound);
            }
            order.Status= orderStatus;
             _unitOfWork.GetRepository<Order>().UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            await SendOrderStatusUpdateEmail(order);
            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }

        private async Task SendOrderStatusUpdateEmail(Order order)
        {
            string subject = $"Siparişinizin Durumu Güncellendi: {order.Status.ToString()}";

            try
            {
                var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "OrderStatusUpdateMailTemplate.liquid");

                if (!File.Exists(templatePath))
                {
                    throw new FileNotFoundException($"Şablon dosyası bulunamadı: {templatePath}");
                }

                var templateText = await File.ReadAllTextAsync(templatePath);

                var parser = new FluidParser();
                if (!parser.TryParse(templateText, out var template, out var error))
                {
                    throw new InvalidOperationException("Şablon ayrıştırma hatası: " + error);
                }

                var templateContext = new TemplateContext();

                var orderData = new Dictionary<string, object>
        {
            { "OrderNumber", order.OrderNumber.ToString() },
            { "OrderStatus", order.Status.ToString() }
        };
                //TODO : Invoicenumber

                templateContext.SetValue("order", orderData);

                var body = template.Render(templateContext);

                await emailService.SendEmailAsync(order.Invoice.Email, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
                throw;
            }
        }
    }


}


