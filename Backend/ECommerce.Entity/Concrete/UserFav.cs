﻿using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class UserFav :BaseEntity
    {

        public string UserId { get; set; }
        public NormalUser User { get; set; } 
        public int? ProductId { get; set; }
        public Product Product { get; set; } 
    }
}
