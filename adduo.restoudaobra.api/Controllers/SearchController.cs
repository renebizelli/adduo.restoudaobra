using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    public class SearchController : BaseApiController
    {
        private SearchManager searchManager { get; set; }

        public SearchController(SearchManager searchManager)
        {
            this.searchManager = searchManager;
        }

        [HttpGet]
        [Authorize("Bearer")]
        [Route("search")]
        public ObjectResult Get(string term)
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



    }
}
