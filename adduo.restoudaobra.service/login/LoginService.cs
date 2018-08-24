using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.ie.providers;
using adduo.restoudaobra.ie.service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace adduo.restoudaobra.service.login
{
    public class LoginService : BaseService, ILoginService
    {
        public IOwnerService ownerService { get; set; }
        public ITokenConfigurations tokenConfigurations { get; set; }
        public ISigningConfigurations signingConfigurations { get; set; }

        public LoginService(
            IOwnerService ownerService,
            ITokenConfigurations tokenConfigurations,
            ISigningConfigurations signingConfigurations)
        {
            this.ownerService = ownerService;
            this.tokenConfigurations = tokenConfigurations;
            this.signingConfigurations = signingConfigurations;
        }

        private BaseResponse<OwnerAuthenticatedDTO> Authentication(OwnerDTO owner)
        {
            var response = new BaseResponse<OwnerAuthenticatedDTO>();

            var identity = new ClaimsIdentity(new GenericIdentity(owner.id.ToString(), "id"), new[] { new Claim(JwtRegisteredClaimNames.NameId, owner.id.ToString()) });

            identity.AddClaim(new Claim("id", owner.id.ToString()));

            var expires = DateTime.Now.AddYears(10);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = DateTime.Now,
                Expires = expires
            });

            var token = handler.WriteToken(securityToken);

            response.Dto.Token = new TokenDTO()
            {
                Hash = token,
                Type = "Bearer",
            };

            response.Dto.Name = owner.FirstName.Value;

            response.Success = true;

            return response;
        }

        public BaseResponse<OwnerAuthenticatedDTO> Login(OwnerDTO owner)
        {
            var response = new BaseResponse<OwnerAuthenticatedDTO>();

            var code = ERROR_CODE.NONE;

            if (owner == null)
            {
                code = ERROR_CODE.INVALID;
            }
            else if (!owner.id.Equals(0))
            {
                response.Dto.Name = owner.FirstName.Value;

                if (owner.Status.Equals(OWNER_STATUS.WAITING_ACTIVATION))
                {
                    code = ERROR_CODE.INACTIVE;
                }
                else
                {
                    response = Authentication(owner);
                }
            }

            response.Error = new ErrorEnvelope { Code = code };

            return response;
        }
    }
}
