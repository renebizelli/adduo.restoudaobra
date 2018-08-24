using adduo.basetype.filter;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.ad
{
    public class AdStatusService : BaseService, IAdStatusService
    {
        private IAdStatusDAL adStatusDAL { get; set; }

        public AdStatusService(IAdStatusDAL adStatusDAL)
        {
            this.adStatusDAL = adStatusDAL;
        }

        public void List(BaseFilter filter, IParser parser)
        {
            adStatusDAL.List(filter, parser);
        }
    }
}
