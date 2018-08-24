using adduo.basetype.result;
using adduo.restoudaobra.dal.framework.database;
using Microsoft.Extensions.Configuration;

namespace adduo.restoudaobra.dal
{
    public class BaseDAL<T> where T : BaseResult
    {
        public DapperFriendly dapper { get; set; }
        public IConfiguration configuration { get; set; }

    }
}
