using adduo.helper.property;
using adduo.helper.property.validation;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.owner.validation
{
    public class CPFNotFoundValidation : PropertyDtoBaseValidation<string>,  IPropertyDtoValidation<string>
    {
        private IOwnerService ownerService { get; set; }

        public CPFNotFoundValidation(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public void Validate()
        {
            if (property.Status != PROPERTY_STATUS.INVALID)
            {
                var found = ownerService.Already(new OwnerFilter { CPF = property.Value });
                SetStatus(found, ERROR_CODE.NOTFOUND);
            }
        }
    }
}
