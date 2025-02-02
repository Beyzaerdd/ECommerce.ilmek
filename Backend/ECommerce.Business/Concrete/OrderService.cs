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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

           if(basketDTO.BasketItems.Any(item => !item.Product.IsActive))
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
                    Status = OrderStatus.Pending,
                    TotalPrice = 0,
                    OrderItems = new List<OrderItem>()
                };

                foreach (var basketItem in seller)
                {
                    var product = basketItem.Product;

                    var basketItemDTO = basketDTO.BasketItems.FirstOrDefault(bi => bi.ProductId == basketItem.ProductId);
                    if (basketItemDTO != null)
                    {
                        decimal itemTotalPrice = basketItemDTO.DiscountedPrice * basketItem.Quantity;

                        var orderItem = new OrderItem
                        {
                            ProductId = basketItem.ProductId,
                            Quantity = basketItem.Quantity,
                            TotalPrice = itemTotalPrice
                        };

                        orderTotalAmount += itemTotalPrice;
                        order.OrderItems.Add(orderItem);
                    }
                }

                order.TotalPrice = orderTotalAmount;
                order.OrderNumber = GenerateOrderNumber();


                await _unitOfWork.GetRepository<Order>().AddAsync(order);
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

            SendOrderMail(createdOrders);
            
            foreach (var invoice in createdInvoice)
            {
                SendInvoiceMail(invoice);
            }
            await basketService.ClearBasketAsync();

            return ResponseDTO<IEnumerable<OrderDTO>>.Success(_mapper.Map<List<OrderDTO>>(createdOrders), HttpStatusCode.Created);
        }

        private void SendInvoiceMail(InvoiceDTO ınvoice)
        {
            string subject = "Faturanız Oluşturulmuştur!";
            StringBuilder body = new StringBuilder();
           


                body.AppendLine("Fatura Numarası :" + ınvoice.InvoiceNumber);
                body.AppendLine("Ürünler:");
                foreach (var orderItem in ınvoice.Order.OrderItems)
                {
                    body.AppendLine($"{orderItem.Product.Name}  : {orderItem.Quantity} :{orderItem.TotalPrice} TL");

                }

                body.AppendLine("Toplam Tutar:" + ınvoice.TotalPrice);
            
            emailService.SendEmailAsync(ınvoice.Order.ApplicationUserName, subject, body.ToString());

        }

        private void SendOrderMail(IEnumerable<Order> orders)
        {
            string subject = "Siparişiniz Alınmıştır!";
            StringBuilder body = new StringBuilder();
            foreach (var order in orders)
            {


                body.AppendLine("Sipariş Numarası :" + order.OrderNumber);
                body.AppendLine("Ürünler:");
                foreach (var orderItem in order.OrderItems)
                {
                    body.AppendLine($"{orderItem.Product.Name} : {orderItem.Product.ImageUrl} : {orderItem.TotalPrice} TL");

                }

                body.AppendLine("Toplam Tutar:" + order.TotalPrice);
                }
            emailService.SendEmailAsync(orders.FirstOrDefault().ApplicationUser.Email, subject, body.ToString());

        }

        private string GenerateOrderNumber(int length = 10)
        {
            var random = RandomNumberGenerator.Create();
            var bytes = new byte[length];
            random.GetNonZeroBytes(bytes);
            var result = BitConverter.ToInt32(bytes);
            return result.ToString();
        }



        public async Task<ResponseDTO<NoContent>> DeleteOrderAsync(int id)
        {
            var order = _mapper.Map<Order>(id);
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
            var order = await _unitOfWork.GetRepository<Order>().GetAsync(x => x.Id == id, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
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
            return ResponseDTO<OrderDTO>.Success(orderDTO, HttpStatusCode.OK);

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

    }
}


