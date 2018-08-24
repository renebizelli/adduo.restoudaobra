using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.parser
{
    public class OwnerDTOParser : BaseParser<OwnerRegisterDTO>, IParser
    {
        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result != null)
            {
                var ownerRegisterDTO = (OwnerDTO)dto;

                var ownerResult = (OwnerResult)result;

                ownerRegisterDTO.id = ownerResult.id;
                ownerRegisterDTO.Guid.Value = ownerResult.Guid;
                ownerRegisterDTO.FirstName.Value = ownerResult.FirstName;
                ownerRegisterDTO.LastName.Value = ownerResult.LastName;
                ownerRegisterDTO.Email.Value = ownerResult.Email;
                ownerRegisterDTO.Cpf.Value = ownerResult.CPF;
                ownerRegisterDTO.Phone.Value = ownerResult.Phone;
                ownerRegisterDTO.CellPhone.Value = ownerResult.CellPhone;
                ownerRegisterDTO.Status = (OWNER_STATUS)ownerResult.idStatus;
                ownerRegisterDTO.Created = ownerResult.Created;
                ownerRegisterDTO.Confirmated = ownerResult.Confirmated;
            }
        }
    }
}
