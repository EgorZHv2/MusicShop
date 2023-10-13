using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class WrongEmailAddressException:ApiException
    {
        public WrongEmailAddressException():base("Wrong email",System.Net.HttpStatusCode.Unauthorized) { }
    }
}
