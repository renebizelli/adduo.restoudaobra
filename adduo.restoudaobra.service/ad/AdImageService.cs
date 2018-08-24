using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.methodextension;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.parser;
using System;
using System.IO;
using System.Linq;

namespace adduo.restoudaobra.service.ad
{
    public class AdImageService : BaseService, IAdImageService
    {
        private IAdImageDAL adImageDAL { get; set; }
        private AdImageDTOParser adImageDTOParser { get; set; }
        private IAdImagePath adImagePathHelper { get; set; }

        public AdImageService(
            IAdImageDAL adImageDAL,
            AdImageDTOParser adImageDTOParser,
            IAdImagePath adImagePathHelper)
        {
            this.adImageDAL = adImageDAL;
            this.adImageDTOParser = adImageDTOParser;
            this.adImagePathHelper = adImagePathHelper;
        }

        public BaseResponse<AdImageDTO> Save(BaseRequest<AdImageDTO> request)
        {
            request.Dto.CreateAt = DateTime.Now.AjustNow();

            adImageDAL.Save(request.Dto);

            return request.CreateResponse();
        }

        public bool Delete(BaseRequest<AdImageDTO> request)
        {
            var filter = new AdImageFilter { id = request.Dto.id, idOwner = request.Dto.idOwner };

            adImageDAL.Get(filter, adImageDTOParser);

            var dto = (AdImageDTO)adImageDTOParser.Get();

            //##TODO verificar se e necessario esse processo, se no parser ja conseguimos fazer isso.
            adImagePathHelper.SetGuidProduct(dto.GuidProduct);

            var full = adImagePathHelper.FullPhysicalPath(dto.File);

            if (File.Exists(full))
            {
                File.Delete(full);

                adImageDAL.Delete(filter);
            }

            return true;
        }

        public void List(AdImageFilter filter, IParser parser)
        {
            adImageDAL.List(filter, parser);
        }

        public bool Validation(Guid guid)
        {
            var filter = new AdImageFilter { GuidProduct = guid };
            return Any(filter);
        }

        public bool Any(AdImageFilter filter)
        {
            return this.adImageDAL.Any(filter);
        }
    }
}
