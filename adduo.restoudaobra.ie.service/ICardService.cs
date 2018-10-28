using System;
using adduo.restoudaobra.dto.filter;

namespace adduo.restoudaobra.ie.service
{
    public interface ICardService :
        IGetService<AdFilter>
    {
        void IncrementContactView(Guid guid);
    }
}
