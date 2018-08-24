using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.parser
{
    public class AdRegisterDTOParser : BaseParser<AdRegisterDTO>, IParser
    {
        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result != null)
            {
                var adRegisterDTO = (AdRegisterDTO)dto;

                var addressResult = (AdResult)result;

                adRegisterDTO.id = addressResult.id;
                adRegisterDTO.Name.Value = addressResult.Name;
                adRegisterDTO.Brand.Value = addressResult.Brand;
                adRegisterDTO.Option.Value = addressResult.Option;
                adRegisterDTO.Price.Value = addressResult.Price;
                adRegisterDTO.Quantity.Value = addressResult.Quantity;
                adRegisterDTO.idAddress = addressResult.idAddress;
                adRegisterDTO.Guid = addressResult.Guid;

                adRegisterDTO.Status = (AD_STATUS)addressResult.idStatus;
                adRegisterDTO.StatusName = addressResult.StatusName;

                adRegisterDTO.Type = (AD_TYPE)addressResult.idType;

                adRegisterDTO.idOwner = addressResult.idOwner;

                adRegisterDTO.Created = addressResult.Created;
            }
        }
    }
}
