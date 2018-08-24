using adduo.helper.property;
using adduo.helper.property.validation;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.owner.validation
{
    public class EmailNotFoundValidation : PropertyDtoBaseValidation<string>,  IPropertyDtoValidation<string>
    {
        private IOwnerService ownerService { get; set; }

        public EmailNotFoundValidation(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public void Validate()
        {
            if (CanValidate())
            {           
                var already = ownerService.Already(new OwnerFilter { Email = property.Value });
                SetStatus(already, ERROR_CODE.NOTFOUND);
            }
        }
    }
}
