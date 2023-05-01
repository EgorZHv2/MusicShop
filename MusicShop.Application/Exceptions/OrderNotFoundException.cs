using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class OrderNotFoundException:ApiException
    {
         public OrderNotFoundException():base("order not found",System.Net.HttpStatusCode.NotFound) { }
    }
}
