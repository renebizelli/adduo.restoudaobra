using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.parser;
using Microsoft.Extensions.Configuration;
using System;

namespace adduo.restoudaobra.service.owner
{
    public class OwnerManager : BaseManager
    {
        private IOwnerService ownerService { get; set; }
        private IOwnerRegisterService ownerRegisterService { get; set; }
        private IOwnerUpdateService ownerUpdateService { get; set; }
        private IOwnerConfirmationService ownerConfirmationService { get; set; }
        private ILoginService loginService { get; set; }
        private IOwnerResetPasswordService ownerResetPasswordService { get; set; }

        public OwnerManager(
            IOwnerService ownerService,
            IOwnerRegisterService ownerRegisterService,
            IOwnerUpdateService ownerUpdateService,
            IOwnerConfirmationService ownerConfirmationService,
            IOwnerResetPasswordService ownerResetPasswordService,
            ILoginService loginService,
            IConfiguration configuration,
            IAppSettings settings)
        {
            this.ownerService = ownerService;
            this.ownerRegisterService = ownerRegisterService;
            this.ownerUpdateService = ownerUpdateService;
            this.ownerConfirmationService = ownerConfirmationService;
            this.loginService = loginService;
            this.ownerResetPasswordService = ownerResetPasswordService;
        }

        public OwnerDTO Get(int id)
        {
            var filter = new OwnerFilter()
            {
                idOwner = id
            };

            return Get(filter);
        }

        public OwnerDetailDTO GetContact(Guid guid)
        {
            var filter = new OwnerFilter()
            {
                GuidAd = guid
            };

            var parser = new OwnerDetailDTOParser();

            ownerService.Get(filter, parser);

            var owner = (OwnerDetailDTO)parser.Get();

            return owner;

        }

        public OwnerDTO Get(string email, string password)
        {
            var filter = new OwnerFilter { Email = email, Password = password };

            return Get(filter);
        }

        private OwnerDTO Get(OwnerFilter filter)
        {
            var parser = new OwnerDTOParser();

            ownerService.Get(filter, parser);

            var owner = (OwnerDTO)parser.Get();

            return owner;
        }

        public BaseResponse<OwnerUpdateDTO> Update(BaseRequest<OwnerUpdateDTO> request)
        {
            return ownerUpdateService.Update(request);
        }

        public BaseResponse<OwnerRegisterDTO> Save(BaseRequest<OwnerRegisterDTO> request)
        {
            return ownerRegisterService.Save(request);
        }

        public BaseResponse<OwnerAuthenticatedDTO> Confirmation(BaseRequest<OwnerConfirmationDTO> request)
        {
            var response = new BaseResponse<OwnerAuthenticatedDTO>();

            var responseConfirmation = ownerConfirmationService.Confirmation(request);

            if (responseConfirmation.Success)
            {
                response = Login(responseConfirmation.Dto);
            }
            else {
                response = responseConfirmation.Clone<OwnerAuthenticatedDTO>();
            }

            return response;
        }

        public void SendEmail(OwnerResendDTO dto)
        {
            ownerConfirmationService.SendEmail(dto);
        }

        public BaseResponse<OwnerAuthenticatedDTO> Login(OwnerDTO dto)
        {
            var response = new BaseResponse<OwnerAuthenticatedDTO>();

            response = loginService.Login(dto);

            return response;
        }

        public BaseResponse<OwnerAuthenticatedDTO> Login(string email)
        {
            var parser = new OwnerDTOParser();

            ownerService.Get(new OwnerFilter { Email = email }, parser);

            var owner = (OwnerDTO)parser.Get();

            return Login(owner);
        }

        public BaseResponse<OwnerAuthenticatedDTO> Login(LoginDTO loginDTO)
        {
            var response = new BaseResponse<OwnerAuthenticatedDTO>();

            loginDTO.Email.Validate();
            loginDTO.Password.Validate();

            if (loginDTO.Email.IsValid() &&
                loginDTO.Password.IsValid())
            {
                var parser = new OwnerDTOParser();

                ownerService.Get(new OwnerFilter { Email = loginDTO.Email.Value, Password = loginDTO.Password.Value }, parser);

                var owner = (OwnerDTO)parser.Get();

                response = Login(owner);
            }
            else
            {
                response.Error = new ErrorEnvelope { Code = ERROR_CODE.INVALID };
            }

            return response;
        }

        public BaseResponse<OwnerAuthenticatedDTO> Login(OwnerConfirmationDTO confirmationDTO)
        {
            var parser = new OwnerDTOParser();

            ownerService.Get(new OwnerFilter { Guid = confirmationDTO.Guid }, parser);

            var owner = (OwnerDTO)parser.Get();

            return Login(owner);
        }

        public BaseResponse<OwnerAuthenticatedDTO> Login(Guid key)
        {
            var parser = new OwnerDTOParser();

            ownerService.Get(new OwnerFilter { RedefinePasswordKey = key }, parser);

            var owner = (OwnerDTO)parser.Get();

            return Login(owner);
        }

        public BaseResponse<RedefinePasswordSolicitationDTO> Solicitation(BaseRequest<RedefinePasswordSolicitationDTO> request)
        {
            return ownerResetPasswordService.Solicitation(request);
        }

        public BaseResponse<RedefinePasswordChangeDTO> Change(BaseRequest<RedefinePasswordChangeDTO> request)
        {
            return ownerResetPasswordService.Change(request);
        }
    }
}
