using adduo.helper.property;
using adduo.helper.property.validation;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.owner.validation
{
    public class CPFAlreadyValidation : PropertyDtoBaseValidation<string>,  IPropertyDtoValidation<string>
    {
        private IOwnerService ownerService { get; set; }
        private int idOwner { get; set; }

        public CPFAlreadyValidation(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public void Set(int idOwner) {
            this.idOwner = idOwner;
        }

        public void Validate()
        {
            if (property.Status != PROPERTY_STATUS.INVALID)
            {
                var already = ownerService.Already(new OwnerFilter { CPF = property.Value, idOwner = idOwner });
                SetStatus(!already, ERROR_CODE.ALREADY);
            }
        }
    }
}
