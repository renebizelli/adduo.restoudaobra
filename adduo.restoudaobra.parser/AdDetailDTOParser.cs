using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.methodextension;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.parser
{
    public class AdDetailDTOParser : BaseParser<AdDetailDTO>, IParser
    {
        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result is AdResult)
            {
                Parse((AdResult)result, (AdDetailDTO)dto);
            }
            else if (result is SearchResult)
            {
                Parse((SearchResult)result, (AdDetailDTO)dto);
            }
        }

        private void Parse(AdResult addressResult, AdDetailDTO adDetailDTO)
        {
            adDetailDTO.id = addressResult.id;
            adDetailDTO.Guid = addressResult.Guid;
            adDetailDTO.Name = addressResult.Name;
            adDetailDTO.Option = addressResult.Option;
            adDetailDTO.Brand = addressResult.Brand;
            adDetailDTO.Quantity = addressResult.Quantity;
            adDetailDTO.Price = addressResult.Price;
            adDetailDTO.Type = (AD_TYPE)addressResult.idType;
            adDetailDTO.Status = (AD_STATUS)addressResult.idStatus;
            adDetailDTO.StatusName = addressResult.StatusName;
            adDetailDTO.Created = addressResult.Created;
        }

        private void Parse(SearchResult searchResult, AdDetailDTO adDetailDTO)
        {
            adDetailDTO.Guid = searchResult.ProductGuid;
            adDetailDTO.Name = searchResult.ProductName;
            adDetailDTO.Brand = searchResult.ProductBrand;
            adDetailDTO.Quantity = searchResult.ProductQuantity;
            adDetailDTO.Price = searchResult.ProductPrice;
            adDetailDTO.Type = (AD_TYPE)searchResult.ProductType;
            adDetailDTO.URL = searchResult.ProductName.CreateUrlFriendly();
        }
    }
}
