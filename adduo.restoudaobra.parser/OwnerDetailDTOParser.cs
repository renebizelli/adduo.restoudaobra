using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.parser
{
    public class OwnerDetailDTOParser : BaseParser<OwnerDetailDTO>, IParser
    {
        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result != null)
            {
                var ownerDetailDTO = (OwnerDetailDTO)dto;

                var ownerResult = (OwnerResult)result;

                ownerDetailDTO.Guid = ownerResult.Guid;
                ownerDetailDTO.FirstName = ownerResult.FirstName;
                ownerDetailDTO.Email = ownerResult.Email;
                ownerDetailDTO.Phone = ownerResult.Phone;
                ownerDetailDTO.CellPhone = ownerResult.CellPhone;
            }
        }
    }
}
