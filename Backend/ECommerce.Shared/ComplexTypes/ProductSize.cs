using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.ComplexTypes
{
    public enum ProductSize
    {

      
        [Display(Name = "0")]
        None = 0,

        [Display(Name = "XS")]
        XS = 1,

        [Display(Name = "S")]
        S = 2,

        [Display(Name = "M")]
        M = 3,

        [Display(Name = "L")]
        L = 4,

        [Display(Name = "XL")]
        XL = 5,

        [Display(Name = "XXL")]
        XXL = 6,

        [Display(Name = "0-3 Aylık")]
        _0M = 7,

        [Display(Name = "3-6 Aylık")]
        _3M = 8,

        [Display(Name = "6-9 Aylık")]
        _6M = 9,

        [Display(Name = "9-12 Aylık")]
        _9M = 10,

        [Display(Name = "1-3 Yaş")]
        _1Y = 11,

        [Display(Name = "3-5 Yaş")]
        _3Y = 12,

        [Display(Name = "5-7 Yaş")]
        _5Y = 13,

        [Display(Name = "7+ Yaş")]
        _7Y = 14,

    }


}

