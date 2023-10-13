using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class ProductPropertyNotFoundException:ApiException
    {
        public ProductPropertyNotFoundException():base("Product property not found",System.Net.HttpStatusCode.NotFound) { }
    }
}
