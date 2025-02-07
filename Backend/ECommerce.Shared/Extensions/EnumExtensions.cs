using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this ProductSize size)
        {
            switch (size)
            {
                case ProductSize.None: return ""; 
                case ProductSize.BirBeden: return "0-1 Beden";
                case ProductSize.İkiBeden: return "1-2 Beden";
                case ProductSize.Bebek: return "Bebek";
                case ProductSize.Çocuk: return "Çocuk";

                default: return size.ToString(); 
            }
        }

        public static string GetDisplayName(this ProductColor color)
        {
            switch (color)
            {
                case ProductColor.Red: return "Kırmızı";
                case ProductColor.Blue: return "Mavi";
                case ProductColor.Pink: return "Pembe";
                case ProductColor.Orange: return "Turuncu";
                case ProductColor.Purple: return "Mor";
                case ProductColor.Gray: return "Gri";
                case ProductColor.Black: return "Siyah";
                case ProductColor.Green: return "Yeşil";
                case ProductColor.Brown: return "Kahverengi";


              
                default: return color.ToString(); 
            }
        }
    }
}

