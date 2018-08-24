using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.methodextension;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.parser;
using adduo.restoudaobra.service.emailhtml;
using adduo.service.email;
using System;

namespace adduo.restoudaobra.service.owner
{
    public class OwnerConfirmationService : OwnerService, IOwnerConfirmationService
    {
        public ConfirmationEmailHtml confirmationEmailHtml { get; set; }

        public OwnerConfirmationService(
            IOwnerDAL ownerDAL, 
            ConfirmationEmailHtml confirmationEmailHtml) : base(ownerDAL)
        {
            this.confirmationEmailHtml = confirmationEmailHtml;
        }

        public BaseResponse<OwnerDTO> Confirmation(BaseRequest<OwnerConfirmationDTO> request)
        {
            var response = new BaseResponse<OwnerDTO>();

            if (request != null &&
                request.Dto != null && 
                request.Dto.Guid != Guid.Empty)
            {
                var parser = new OwnerDTOParser();

                ownerDAL.Get(new OwnerFilter { Guid = request.Dto.Guid }, parser);

                var ownerDTO = (OwnerDTO)parser.Get();

                if (ownerDTO.NotIsNull())
                {
                    if (ownerDTO.Status == OWNER_STATUS.WAITING_ACTIVATION)
                    {
                        try
                        {
                            ownerDTO.Status = OWNER_STATUS.ACTIVE;
                            ownerDTO.Confirmated = DateTime.Now;

                            ownerDAL.Confirmation(ownerDTO);

                            response.Success = true;
                            response.Dto = ownerDTO;
                        }
                        catch (Exception ex)
                        {
                            response.Error = new ErrorEnvelope() { Code = ERROR_CODE.ERRO };
                        }
                    }
                    else
                    {
                        response.Error = new ErrorEnvelope() { Code = ERROR_CODE.ALREADY };
                    }
                }
                else
                {
                    response.Error = new ErrorEnvelope() { Code = ERROR_CODE.EMPTY };
                }
            }
            else
            {
                response.Error = new ErrorEnvelope() { Code = ERROR_CODE.EMPTY };
            }

            if (response.Error.Code != ERROR_CODE.NONE) {
                response.Dto = null;
            }

            return response;
        }


        public void SendEmail(OwnerDTO dto)
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

        public void SendEmail(OwnerResendDTO dto)
        {
            var parser = new OwnerDTOParser();

            Get(new OwnerFilter { Email = dto.Email.Value }, parser);

            var owner = (OwnerDTO)parser.Get();

            SendEmail(owner);
        }
    }
}
