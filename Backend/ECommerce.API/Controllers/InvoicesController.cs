using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.Shared.DTOs.InvoiceDTOs;
using ECommerce.Shared.DTOs.OrderDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : CustomControllerBase
    {
        private readonly IInvoiceService ınvoiceService;

        public InvoicesController(IInvoiceService ınvoiceService)
        {
            this.ınvoiceService = ınvoiceService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceCreateDTO invoiceCreateDTO)
        {
            var response = await ınvoiceService.CreateInvoiceAsync(invoiceCreateDTO);
            return CreateResponse(response);
        }

        [HttpGet("getInvoiceby/{orderId}")]
        public async Task<IActionResult> GetInvoiceByOrderId(int orderId)
        {
            var response = await ınvoiceService.GetInvoiceByOrderIdAsync(orderId);
            return CreateResponse(response);
        }

        }
}
