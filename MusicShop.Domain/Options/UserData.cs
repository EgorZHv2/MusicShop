﻿using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Options
{
    public class UserData
    {
        public CultureInfo CultureInfo { get;set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
       
    }
}
