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
        Bekliyor = 1,
        [Display(Name = "Hazırlanıyor")]
        Hazırlanıyor = 2,
        [Display(Name = "Kargoya verildi")]
        Kargoda = 3,
        [Display(Name = "Sipariş Teslim Edildi")]
        Teslim = 4,
        [Display(Name = "Sipariş Tamamlandı")]
        Tamamlandı =5,
        [Display(Name = "İptal")]
        İptal = 6,
      [Display(Name = "İade")]
        İade = 7      
    }
}
