using ECommerce.Shared.DTOs.InvoiceDTOs;
using ECommerce.Shared.DTOs.OrderDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IInvoiceService
    {

        Task<ResponseDTO<InvoiceDTO>> CreateInvoiceAsync(InvoiceCreateDTO invoiceCreateDTO);
        Task<ResponseDTO<InvoiceDTO>> GetInvoiceByOrderIdAsync(int orderId);
    }
}
