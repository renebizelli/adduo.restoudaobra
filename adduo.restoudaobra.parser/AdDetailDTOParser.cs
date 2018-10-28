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

        private void Parse(AdResult adResult, AdDetailDTO adDetailDTO)
        {
            adDetailDTO.id = adResult.id;
            adDetailDTO.Guid = adResult.Guid;
            adDetailDTO.Name = adResult.Name;
            adDetailDTO.Option = adResult.Option;
            adDetailDTO.Brand = adResult.Brand;
            adDetailDTO.Quantity = adResult.Quantity;
            adDetailDTO.Price = adResult.Price;
            adDetailDTO.Type = (AD_TYPE)adResult.idType;
            adDetailDTO.Status = (AD_STATUS)adResult.idStatus;
            adDetailDTO.StatusName = adResult.StatusName;
            adDetailDTO.Created = adResult.Created;
            adDetailDTO.ViewContact = adResult.ViewContact;
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
            adDetailDTO.ViewContact = searchResult.ProductViewContact;


        }
    }
}
