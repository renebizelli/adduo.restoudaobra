using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace adduo.restoudaobra.ie.providers
{
    public interface ISigningConfigurations
    {
        SecurityKey Key { get; set; }
        SigningCredentials SigningCredentials { get; set; }
    }
}
