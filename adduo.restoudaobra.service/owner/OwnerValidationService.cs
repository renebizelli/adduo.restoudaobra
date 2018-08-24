using adduo.helper.property;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace adduo.restoudaobra.service.owner
{
    public class OwnerValidationService : IOwnerValidationService
    {
        public void Validation(OwnerDTO dto) {

            foreach (var propertyDto in dto.Properties)
            {
                propertyDto.Validate();
            }

            if (dto.Phone.IsInvalidOrEmpty() &&
                dto.CellPhone.IsInvalidOrEmpty())
            {
                dto.Phone.Status = PROPERTY_STATUS.INVALID;
                dto.CellPhone.Status = PROPERTY_STATUS.INVALID;
                dto.CellPhone.Code = ERROR_CODE.EMPTY;
            }
            else if (dto.Phone.IsValid() && dto.CellPhone.Code == ERROR_CODE.EMPTY)
            {
                dto.CellPhone.Status = PROPERTY_STATUS.NONE;
            }
            else if (dto.CellPhone.IsValid() && dto.Phone.Code == ERROR_CODE.EMPTY)
            {
                dto.Phone.Status = PROPERTY_STATUS.NONE;
            }
        }
    }
}
