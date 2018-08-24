using adduo.basetype.filter;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.ie.dal
{
    public interface IGetDAL<TFilter>
    where TFilter : BaseFilter
    {
        void Get(TFilter filter, IParser arser);
    }
}
