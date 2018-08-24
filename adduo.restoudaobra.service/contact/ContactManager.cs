using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.contact
{
    public class ContactManager : BaseManager
    {
        public IContactService contactService { get; set; }

        public ContactManager(IContactService contactService) 
        {
            this.contactService = contactService;
        }

        public BaseResponse<ContactDTO> Send(BaseRequest<ContactDTO> request)
        {
            return contactService.Send(request);    
        }
    }
}
