using adduo.helper.property;
using adduo.helper.property.validation;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.owner.validation
{
    public class EmailAlreadyValidation : PropertyDtoBaseValidation<string>,  IPropertyDtoValidation<string>
    {
        private IOwnerService ownerService { get; set; }
        private int idOwner { get; set; }

        public EmailAlreadyValidation(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public void Set(int idOwner)
        {
            this.idOwner = idOwner;
        }

        public void Validate()
        {
            if (CanValidate())
            {
                var already = ownerService.Already(new OwnerFilter { Email = property.Value, idOwner = idOwner });
                SetStatus(!already, ERROR_CODE.ALREADY);
            }
        }
    }
}
