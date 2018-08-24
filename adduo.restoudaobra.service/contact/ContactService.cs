using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.service.emailhtml;
using adduo.service.email;

namespace adduo.restoudaobra.service.contact
{
    public class ContactService : BaseService, IContactService
    {
        public ContactEmailHtml contactEmailHtml { get; set; }

        public ContactService(IEmailService emailService, ContactEmailHtml contactEmailHtml, IAppSettings settings)
        {
            this.emailService = emailService;
            this.contactEmailHtml = contactEmailHtml;
            this.settings = settings;
        }

        public BaseResponse<ContactDTO> Send(BaseRequest<ContactDTO> request)
        {
            Validation(request);

            if (request.Success)
            {
                contactEmailHtml.Set(request.Dto);
                contactEmailHtml.Create();

                var emailDTO = new EmailDTO()
                {
                    To = new EmailAccountDTO { Name = "Contato - Restou da Obra", Email = settings.EmailContact },
                    Replay = new EmailAccountDTO { Name = request.Dto.Name.Value, Email = request.Dto.Email.Value },
                    Subject = string.Format("[Contato] {0}", request.Dto.Name.Value),
                    EmailHtml = contactEmailHtml
                };

                emailService.Send(emailDTO);

                request.Success = true;
            }

            return request.CreateResponse();
        }

        private void Validation(BaseRequest<ContactDTO> request)
        {
            PropertyHelper.ResetProperty(request.Dto);

            foreach (var propertyDto in request.Dto.Properties)
            {
                propertyDto.Validate();
            }

            if (request.Dto.Phone.Status == PROPERTY_STATUS.INVALID && request.Dto.Phone.Code == ERROR_CODE.EMPTY) {
                request.Dto.Phone.Status = PROPERTY_STATUS.NONE;
                request.Dto.Phone.Code = ERROR_CODE.NONE;
            } 

            request.Success = PropertyHelper.ReturnFalseIfAnyInvalid(request.Dto);
        }
    }
}
