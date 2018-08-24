using adduo.basetype.dto;
using adduo.basetype.filter;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.ie.service
{
    public interface IAnyService<TFilter>
    where TFilter : BaseFilter
    {
        bool Any(TFilter filter);
    }
}
