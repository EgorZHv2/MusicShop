using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class ReviewNotFoundException:ApiException
    {
        public ReviewNotFoundException():base("review not found",System.Net.HttpStatusCode.NotFound) { }
    }
}
