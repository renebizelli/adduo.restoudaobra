using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.helper.property.validation;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.service.emailhtml;
using adduo.restoudaobra.service.owner.validation;
using adduo.service.email;
using Microsoft.Extensions.Configuration;
using System;

namespace adduo.restoudaobra.service.owner
{
    public class OwnerRegisterService : BaseService, IOwnerRegisterService
    {
        private IOwnerDAL ownerDAL { get; set; }
        private IOwnerValidationService validation { get; set; }

        public CPFAlreadyValidation cpfAlreadyValidation { get; set; }
        public EmailAlreadyValidation emailAlreadyValidation { get; set; }
        public ConfirmationEmailHtml confirmationEmailHtml { get; set; }

        public OwnerRegisterService(
            IOwnerDAL ownerDAL,
            IEmailService emailService,
            IConfiguration configuration,
            IAppSettings settings,
            IOwnerValidationService validation,
            CPFAlreadyValidation cpfAlreadyValidation,
            EmailAlreadyValidation emailAlreadyValidation,
            ConfirmationEmailHtml confirmationEmailHtml
            )
        {
            this.emailService = emailService;
            this.cpfAlreadyValidation = cpfAlreadyValidation;
            this.emailAlreadyValidation = emailAlreadyValidation;
            this.confirmationEmailHtml = confirmationEmailHtml;

            this.ownerDAL = ownerDAL;
            this.validation = validation;
        }

        public BaseResponse<OwnerRegisterDTO> Save(BaseRequest<OwnerRegisterDTO> request)
        {
            Validation(request);

            if (request.Success)
            {
                request.Dto.Status = OWNER_STATUS.WAITING_ACTIVATION;

                try
                {
                    ownerDAL.Save(request.Dto);
                    SendConfirmationRegister(request.Dto);
                }
                catch (Exception ex)
                {
                    ownerDAL.Delete(new OwnerFilter { Guid = request.Dto.Guid.Value });

                    request.Success = false;
                    request.Error = new ErrorEnvelope { Exception = ex, Code = ERROR_CODE.ERRO };
                }
            }

            return request.CreateResponse();
        }

        private void Validation(BaseRequest<OwnerRegisterDTO> request)
        {
            PropertyHelper.ResetProperty(request.Dto);

            request.Dto.Cpf.AddValidation(cpfAlreadyValidation);
            request.Dto.Email.AddValidation(emailAlreadyValidation);
            request.Dto.Password.AddValidation(new PropertyDtoCompareValidation(request.Dto.PasswordConfirm));
            request.Dto.Email.AddValidation(new PropertyDtoCompareValidation(request.Dto.EmailConfirm));

            this.validation.Validation(request.Dto);

            request.Success = PropertyHelper.ReturnFalseIfAnyInvalid(request.Dto);
        }

        private void SendConfirmationRegister(OwnerDTO dto)
        {
            confirmationEmailHtml.Set(dto);
            confirmationEmailHtml.Create();

            var emailDTO = new EmailDTO()
            {
                To = new EmailAccountDTO { Name = dto.FirstName.Value, Email = dto.Email.Value },
                Subject = "[Restou da Obra] Confirmação de cadastro",
                EmailHtml = confirmationEmailHtml
            };

            emailService.Send(emailDTO);
        }
    }
}
