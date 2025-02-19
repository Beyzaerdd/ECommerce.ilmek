using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.ComplexTypes
{
    public enum ProductColor
    {
        [Display(Name = "Siyah")]
        Siyah = 1,

        [Display(Name = "Beyaz")]
        Beyaz = 2,

        [Display(Name = "Kırmızı")]
        Kırmızı = 3,

        [Display(Name = "Mavi")]
        Mavi = 4,

        [Display(Name = "Yeşil")]
        Yeşil = 5,

        [Display(Name = "Sarı")]
        Sarı = 6,

        [Display(Name = "Pembe")]
        Pembe = 7,

        [Display(Name = "Turuncu")]
        Turuncu = 8,

        [Display(Name = "Mor")]
        Mor = 9,

        [Display(Name = "Gri")]
        Gri = 10,

        [Display(Name = "Kahverengi")]
        Kahverengi = 11,

        [Display(Name = "Lacivert")]
        Lacivert = 12,

        [Display(Name = "Bordo")]
        Bordo = 13,

        [Display(Name = "Taş")]
        Taş = 14,


        [Display(Name = "Krem")]
        Krem = 15,



    }
}
