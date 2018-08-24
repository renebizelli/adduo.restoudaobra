using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.owner
{
    public class OwnerService : BaseService, IOwnerService
    {
        protected IOwnerDAL ownerDAL { get; set; }

        public OwnerService(IOwnerDAL ownerDAL)
        {
            this.ownerDAL = ownerDAL;
        }

        public void Get(OwnerFilter filter, IParser parser)
        {
            ownerDAL.Get(filter, parser);
        }

        public bool Already(OwnerFilter filter)
        {
            return ownerDAL.Already(filter);
        }
    }
}
