using System;
using adduo.restoudaobra.dto.filter;

namespace adduo.restoudaobra.ie.dal
{
    public interface ICardDAL :
        IGetDAL<AdFilter>
    {
        void IncrementContactView(Guid guid);
    }
}
