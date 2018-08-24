using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.service.ad;
using Microsoft.AspNetCore.Hosting;

namespace adduo.restoudaobra.parser
{
    public class AdImageDTOParser : BaseParser<AdImageDTO>, IParser
    {
        public IHostingEnvironment hostingEnvironment { get; set; }
        private IAppSettings settings { get; set; }
        private IAdImagePath adImagePathHelper { get; set; }

        public AdImageDTOParser(IHostingEnvironment hostingEnvironment, IAppSettings settings, IAdImagePath adImagePathHelper)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.settings = settings;
            this.adImagePathHelper = adImagePathHelper;
        }

        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result is AdImageResult)
            {
                Parse((AdImageResult)result, (AdImageDTO)dto);
            }
            else if (result is SearchResult)
            {
                Parse((SearchResult)result, (AdImageDTO)dto);
            }
        }

        private void Parse(AdImageResult adImageResult, AdImageDTO adImageDTO)
        {
            adImageDTO.id = adImageResult.id;
            adImageDTO.GuidProduct = adImageResult.GuidProduct;
            adImageDTO.File = adImageResult.ImageFile;

            adImagePathHelper.SetGuidProduct(adImageDTO.GuidProduct);
            adImageDTO.Full = adImagePathHelper.FullRelativePath(adImageDTO.File);
        }

        private void Parse(SearchResult searchResult, AdImageDTO adImageDTO)
        {

            adImageDTO.GuidProduct = searchResult.ProductGuid;
            adImageDTO.File = searchResult.ImageFile;

            adImagePathHelper.SetGuidProduct(adImageDTO.GuidProduct);
            adImageDTO.Full = adImagePathHelper.FullRelativePath(adImageDTO.File);
        }
    }
}
