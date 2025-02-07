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
        Black = 1,

        [Display(Name = "Beyaz")]
        White = 2,

        [Display(Name = "Kırmızı")]
        Red = 3,

        [Display(Name = "Mavi")]
        Blue = 4,

        [Display(Name = "Yeşil")]
        Green = 5,

        [Display(Name = "Sarı")]
        Yellow = 6,

        [Display(Name = "Pembe")]
        Pink = 7,

        [Display(Name = "Turuncu")]
        Orange = 8,

        [Display(Name = "Mor")]
        Purple = 9,

        [Display(Name = "Gri")]
        Gray = 10,

        [Display(Name = "Kahverengi")]
        Brown = 11
    }
}
