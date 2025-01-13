using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.ComplexTypes
{
    public enum OrderStatus
    {
        [Description("Waiting for Approval")]
        Pending = 1,
        [Description("Processing Order")]
        Processing = 2,
        [Description("Order Shipped")]
        Shipped = 3,
        [Description("Order Delivered")]
        Delivered = 4,
        [Description("Order is Done")]
        Completed =5,
        [Description("Order Cancelled")]
        Cancelled = 6,
        [Description("Order Returned")]
        Returned = 7      
    }
}
