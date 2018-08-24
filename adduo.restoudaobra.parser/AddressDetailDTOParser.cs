using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.parser
{
    public class AddressDetailDTOParser : BaseParser<AddressDetailDTO>, IParser
    {

        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result is AddressResult)
            {
                Parse((AddressResult)result, (AddressDetailDTO)dto);
            }
            if (result is SearchResult)
            {
                Parse((SearchResult)result, (AddressDetailDTO)dto);
            }
        }

        private void Parse(AddressResult addressResult, AddressDetailDTO addressDetailDTO)
        {
            addressDetailDTO.id = addressResult.id;
            addressDetailDTO.idOwner = addressResult.idOwner;
            addressDetailDTO.State = addressResult.StateName;
            addressDetailDTO.City = addressResult.City;
            addressDetailDTO.District = addressResult.District;
        }

        private void Parse(SearchResult searchResult, AddressDetailDTO addressDetailDTO)
        {
            addressDetailDTO.State = searchResult.AddressStateName;
            addressDetailDTO.City = searchResult.AddressCity;
            addressDetailDTO.District = searchResult.AddressDistrict;
        }
    }
}
