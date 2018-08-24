using adduo.basetype.filter;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.ie.service
{
    public interface IListService<TFilter>
    where TFilter : BaseFilter
    {
        void  List(TFilter filter, IParser parser);
    }
}
