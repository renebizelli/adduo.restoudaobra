using adduo.basetype.filter;
using adduo.basetype.result;
using adduo.restoudaobra.dal.framework.database;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace adduo.restoudaobra.dal
{
    public class AdStatusDAL : BaseDAL<BaseResult>, IAdStatusDAL
    {
        public AdStatusDAL(DapperFriendly dapper, IConfiguration configuration) 
        {
            this.dapper = dapper;
            this.configuration = configuration;
        }

        public void List(BaseFilter filter, IParser parser)
        {
            var ownerResult = dapper
                .ResetParameter()
                .ExecuteWithManyResult<ItemResult>("ad_status_get");

            if (ownerResult.Any())
            {
                parser.Set(ownerResult.Cast<BaseResult>());
            }
        }
    }
}
