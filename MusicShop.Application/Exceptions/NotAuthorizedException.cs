﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class NotAuthorizedException:ApiException
    {
        public NotAuthorizedException():base("Not authorized exception", System.Net.HttpStatusCode.Unauthorized) { }
    }
}
