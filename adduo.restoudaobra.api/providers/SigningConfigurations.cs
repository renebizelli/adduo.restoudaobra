using adduo.restoudaobra.ie.providers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace adduo.restoudaobra.api.providers
{
    public class SigningConfigurations : ISigningConfigurations
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
