using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.search
{
    public class SearchService : BaseService, ISearchService
    {
        private ISearchAdDAL searchDAL { get; set; }

        public SearchService(ISearchAdDAL searchDAL)
        {
            this.searchDAL = searchDAL;
        }

        public void List(SearchFilter filter, IParser parser)
        {
            searchDAL.List(filter, parser);
        }
    }
}
