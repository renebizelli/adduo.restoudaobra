using adduo.restoudaobra.ie.providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adduo.restoudaobra.api.providers
{
    public class TokenConfigurations : ITokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }


}
