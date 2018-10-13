using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.ad;
using adduo.restoudaobra.service.search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    public class SearchController : BaseApiController
    {
        private SearchManager searchManager { get; set; }
        private AdManager adManager { get; set; }

        public SearchController(SearchManager searchManager, AdManager adManager)
        {
            this.searchManager = searchManager;
            this.adManager = adManager;
        }

        [HttpGet]
        [Route("search/list")]
        public ObjectResult List(string term)
        {
            var response = new BaseResponse<CardSearchDTO>();

            try
            {
                var ads = searchManager.Search(term);

                response.AddRange(ads);

                base.PrepareResult<BaseResponse<CardSearchDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<CardSearchDTO>>(response);
            }

            return base.result;
        }


        [HttpGet]
        [Route("search/{guid}")]
        public ObjectResult Get(Guid guid)
        {
            var response = new BaseResponse<CardDetailDTO>();

            try
            {
                response.Dto = adManager.Detail(guid);


                base.PrepareResult<BaseResponse<CardDetailDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<CardDetailDTO>>(response);
            }

            return base.result;
        }



    }
}
