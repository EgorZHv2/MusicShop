﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Enums
{
    public  enum OrderStatus
    {
        None,
        Processed,
        Sent,
        Delivered,
        Completed,
        Сancelled
    }
}
