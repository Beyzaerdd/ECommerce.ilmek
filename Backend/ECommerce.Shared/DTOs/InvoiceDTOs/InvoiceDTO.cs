using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.InvoiceDTOs
{
    public class InvoiceDTO
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
       
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTime IssueDate { get; set; }
    }
}
