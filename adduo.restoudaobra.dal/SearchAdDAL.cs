using adduo.restoudaobra.dal.framework.database;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using Microsoft.Extensions.Configuration;

namespace adduo.restoudaobra.dal
{
    public class SearchAdDAL : BaseDAL<AdResult>, ISearchAdDAL
    {
        public SearchAdDAL(DapperFriendly dapper, IConfiguration configuration)
        {
            this.dapper = dapper;
            this.configuration = configuration;
        }

        public void List(SearchFilter filter, IParser parser)
        {
            var searchAdResults =
                dapper
                .ResetParameter()
                .AddParameter("@Term", filter.Term)
                .AddParameter("@ProductStatusPublished", filter.idStatusAd)
                .AddParameter("@OwnerStatusActive", filter.idStatusOwner)
                .ExecuteWithManyResult<SearchResult>("ad_search");

            parser.Set(searchAdResults);
        }
    }
}
