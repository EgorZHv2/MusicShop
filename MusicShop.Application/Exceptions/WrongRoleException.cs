using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class WrongRoleException:ApiException
    {
        public WrongRoleException() : base("User don't have enough access", System.Net.HttpStatusCode.Forbidden) { }
    }
}
