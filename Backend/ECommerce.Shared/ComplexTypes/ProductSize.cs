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
        [Display(Name = "Tanımsız")]
        None = 0,

        [Display(Name = "Bir Beden")]
        BirBeden = 1,

        [Display(Name = "İki Beden")]
        İkiBeden = 2,

        [Display(Name = "Bebek Beden")]
        Bebek = 7,

        [Display(Name = "Çocuk Beden")]
        Çocuk = 8

    }
}
