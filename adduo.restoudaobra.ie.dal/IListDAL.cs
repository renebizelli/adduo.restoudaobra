using adduo.basetype.filter;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.ie.dal
{
    public interface IListDAL<TFilter>
        where TFilter : BaseFilter
    {
        void List(TFilter filter, IParser parser);
    }

}
