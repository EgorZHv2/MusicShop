using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class EmailALreadyInUseException:ApiException
    {
        public EmailALreadyInUseException():base("Email already in user",System.Net.HttpStatusCode.Unauthorized) { }
    }
}
