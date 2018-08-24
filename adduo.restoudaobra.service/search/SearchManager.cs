using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.parser;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace adduo.restoudaobra.service.search
{
    public class SearchManager : BaseManager
    {
        private IHostingEnvironment hostingEnvironment { get; set; }
        private ISearchService searchService { get; set; }
        private CardSearchDTOParser cardSearchDTOParser  { get; set; }

        public SearchManager(
            IHostingEnvironment hostingEnvironment,
            ISearchService searchService,
            CardSearchDTOParser cardSearchDTOParser)
        {
            this.cardSearchDTOParser = cardSearchDTOParser;

            this.searchService = searchService;
        }

        public List<CardSearchDTO> Search(string term) {

            var filter = new SearchFilter
            {
                Term = term,
                AdStatus = AD_STATUS.PUBLISHED,
                OwnerStatus = OWNER_STATUS.ACTIVE
            };

            searchService.List(filter, cardSearchDTOParser);

            return cardSearchDTOParser.List().Cast<CardSearchDTO>().ToList();
        }
    }
}
