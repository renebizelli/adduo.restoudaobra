using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.parser
{
    public class AddressRegisterDTOParser : BaseParser<AddressRegisterDTO>, IParser
    {
        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result != null)
            {
                var addressDTO = (AddressRegisterDTO)dto;
                var addressResult = (AddressResult)result;

                addressDTO.id.Value = addressResult.id;
                addressDTO.idOwner = addressResult.idOwner;
                addressDTO.State.Value = new ItemDTO { id = addressResult.idState, Name = addressResult.StateName };
                addressDTO.City.Value = addressResult.City;
                addressDTO.District.Value = addressResult.District;
            }
        }
    }
}
