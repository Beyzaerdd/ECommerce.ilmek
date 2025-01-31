using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.InvoiceDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class InvoiceService : IInvoiceService


    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public InvoiceService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseDTO<InvoiceDTO>> CreateInvoiceAsync(InvoiceCreateDTO invoiceCreateDTO)
        {
            
            var order = await unitOfWork.GetRepository<Order>().GetAsync(o => o.Id == invoiceCreateDTO.OrderId, o => o.Include(x => x.OrderItems));

            if (order == null)
            {
                return ResponseDTO<InvoiceDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Order not found",
                Code = "NOT_FOUND",
                Target = "order"
            }
        }, HttpStatusCode.NotFound);
            }

         
            var userId = httpContextAccessor.GetUserId();  
            var user = await unitOfWork.GetRepository<ApplicationUser>().GetAsync(u => u.Id == userId);

            if (user == null)
            {
                return ResponseDTO<InvoiceDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User not found",
                Code = "NOT_FOUND",
                Target = "user"
            }
        }, HttpStatusCode.NotFound);
            }



            var invoice = mapper.Map<Invoice>(invoiceCreateDTO);

            invoice.TotalPrice = order.TotalPrice;
            invoice.InvoiceNumber = GenerateInvoiceNumber();
       
            invoice.Address = user.Address;
            invoice.PhoneNumber = user.PhoneNumber;
            invoice.FirstName= user.FirstName;
            invoice.LastName= user.LastName;
            invoice.Email = user.Email;

          
            await unitOfWork.GetRepository<Invoice>().AddAsync(invoice);
            await unitOfWork.SaveChangesAsync();

            var invoiceDTO = mapper.Map<InvoiceDTO>(invoice);
            invoiceDTO.IssueDate = DateTime.Now; 

            return ResponseDTO<InvoiceDTO>.Success(invoiceDTO, HttpStatusCode.Created);
        }

        public async Task<ResponseDTO<InvoiceDTO>> GetInvoiceByOrderIdAsync(int orderId)
        {
            var invoice = await unitOfWork.GetRepository<Invoice>().GetAsync(i => i.OrderId == orderId);

            if (invoice == null)
            {
                return ResponseDTO<InvoiceDTO>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail
                {
                    Message = "Invoice not found",
                    Code = "NOT_FOUND",
                    Target = "invoice"
                }
            }, HttpStatusCode.NotFound);
            }

            var invoiceDTO = mapper.Map<InvoiceDTO>(invoice);
        

            return ResponseDTO<InvoiceDTO>.Success(invoiceDTO, HttpStatusCode.OK);
        }

        private string GenerateInvoiceNumber()
        {
            return "INV-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

      

      
    }
}
