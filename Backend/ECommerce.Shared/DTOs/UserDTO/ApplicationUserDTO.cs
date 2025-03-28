﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.UsersDTO
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StoreName { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string IdentityNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
    }
}
