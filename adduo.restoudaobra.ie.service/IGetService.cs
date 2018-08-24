using adduo.basetype.dto;
using adduo.basetype.filter;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.ie.service
{
    public interface IGetService<TFilter>
    where TFilter : BaseFilter
    {
        void Get(TFilter filter, IParser parser);
    }
}
