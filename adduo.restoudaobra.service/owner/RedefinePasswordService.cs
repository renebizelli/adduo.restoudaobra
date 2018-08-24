using adduo.basetype.enums;
using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.helper.property.validation;
using adduo.methodextension;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.parser;
using adduo.restoudaobra.service.emailhtml;
using adduo.restoudaobra.service.owner.validation;
using adduo.service.email;
using System;
using System.Threading.Tasks;

namespace adduo.restoudaobra.service.owner
{
    public class RedefinePasswordService : OwnerService, IOwnerResetPasswordService
    {
        private IRefefinePasswordDAL ownerResetPasswordDAL { get; set; }
        private CPFNotFoundValidation cpfNotFoundValidation { get; set; }
        private EmailNotFoundValidation emailNotFoundValidation { get; set; }
        private ResetPasswordSolicitationEmailHtml resetPasswordSolicitationEmailHtml { get; set; }

        public RedefinePasswordService(
            IRefefinePasswordDAL ownerResetPasswordDAL, 
            IOwnerDAL ownerDAL, 
            IEmailService emailService,
            CPFNotFoundValidation cpfNotFoundValidation,
            EmailNotFoundValidation emailNotFoundValidation,
            ResetPasswordSolicitationEmailHtml resetPasswordSolicitationEmailHtml) : base(ownerDAL)
        {
            this.ownerResetPasswordDAL = ownerResetPasswordDAL;
            this.emailService = emailService;
            this.cpfNotFoundValidation = cpfNotFoundValidation;
            this.emailNotFoundValidation = emailNotFoundValidation;
            this.resetPasswordSolicitationEmailHtml = resetPasswordSolicitationEmailHtml;
        }

        public BaseResponse<RedefinePasswordSolicitationDTO> Solicitation(BaseRequest<RedefinePasswordSolicitationDTO> request)
        {
            Validation(request);

            if (request.Success)
            {
                var type = request.Dto.CpfEmail.Value.DataType();

                if (type.Equals(DATA_TYPE.CPF))
                {
                    request.Dto.CPF = request.Dto.CpfEmail.Value;
                }
                else
                {
                    request.Dto.Email = request.Dto.CpfEmail.Value;
                }

                var parser = new OwnerDTOParser();

                Get(new dto.filter.OwnerFilter { CPF = request.Dto.CPF, Email = request.Dto.Email }, parser);

                var owner = (OwnerDTO)parser.Get();

                if (owner == null)
                {
                    throw new Exception();
                }
                else
                {
                    var reset = new RedefineResetPasswordDTO(owner.id, Guid.NewGuid());

                    ownerResetPasswordDAL.Delete(new OwnerFilter { idOwner = owner.id });

                    ownerResetPasswordDAL.Save(reset);

                    request.Dto.EmailOfuscated = owner.Email.Value.EmailOfuscator();

                    Task.Factory.StartNew(() =>
                    {
                        resetPasswordSolicitationEmailHtml.Set(owner, reset.key);
                        resetPasswordSolicitationEmailHtml.Create();

                        var emailDTO = new EmailDTO()
                        {
                            To = new EmailAccountDTO { Name = owner.FirstName.Value, Email = owner.Email.Value },
                            Subject = "[Restou da Obra] Redefinir senha",
                            EmailHtml = resetPasswordSolicitationEmailHtml
                        };

                        emailService.Send(emailDTO);
                    });
                }
            }

            return request.CreateResponse();
        }

        public BaseResponse<RedefinePasswordChangeDTO> Change(BaseRequest<RedefinePasswordChangeDTO> request)
        {
            Validation(request);

            if (request.Success)
            {
                ownerResetPasswordDAL.ChangePassword(request.Dto);
            }

            var response = request.CreateResponse();

            response.Dto.Confirmation.Clear();
            response.Dto.Password.Clear();

            return response;
        }

        public void Validation(BaseRequest<RedefinePasswordChangeDTO> request)
        {
            PropertyHelper.ResetProperty(request.Dto);

            request.Dto.Password.AddValidation(new PropertyDtoCompareValidation(request.Dto.Confirmation));

            foreach (var propertyDto in request.Dto.Properties)
            {
                propertyDto.Validate();
            }

            request.Success = PropertyHelper.ReturnFalseIfAnyInvalid(request.Dto);
        }

        public void Validation(BaseRequest<RedefinePasswordSolicitationDTO> request)
        {
            PropertyHelper.ResetProperty(request.Dto);

            var type = request.Dto.CpfEmail.Value.DataType();

            if (type.Equals(adduo.basetype.enums.DATA_TYPE.CPF))
            {
                request.Dto.CpfEmail.AddValidation(new PropertyDtoCPFValidation());
                request.Dto.CpfEmail.AddValidation(cpfNotFoundValidation);
            }
            else
            {
                request.Dto.CpfEmail.AddValidation(new PropertyDtoEmailValidation());
                request.Dto.CpfEmail.AddValidation(emailNotFoundValidation);
            }

            request.Dto.CpfEmail.Validate();

            request.Success = PropertyHelper.ReturnTrueIfAllValid(request.Dto);
        }

    }
}
