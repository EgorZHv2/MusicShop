using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Options.Configurations
{
    public class JwtTokenConfiguration
    {
        public string JwtAuthKey { get; set; }
        public int JwtExpiresInDays { get; set; }

    }
}
