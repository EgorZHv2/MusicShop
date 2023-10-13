using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class ProductNotFoundException:ApiException
    {
        public ProductNotFoundException():base("product not found",System.Net.HttpStatusCode.NotFound) { }
    }
}
