using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.ComplexTypes
{
    public enum OrderStatus
    {
        [Display(Name = "Onay Bekliyor")]
        Pending = 1,
        [Display(Name = "Hazırlanıyor")]
        Processing = 2,
        [Display(Name = "Kargoya verildi")]
        Shipped = 3,
        [Display(Name = "Sipariş Teslim Edildi")]
        Delivered = 4,
        [Display(Name = "Sipariş Tamamlandı")]
        Completed =5,
        [Display(Name = "İptal")]
        Cancelled = 6,
      [Display(Name = "İade")]
        Returned = 7      
    }
}
