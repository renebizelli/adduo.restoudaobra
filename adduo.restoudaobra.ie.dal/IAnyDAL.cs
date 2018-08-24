using adduo.basetype.filter;

namespace adduo.restoudaobra.ie.dal
{

    public interface IAnyDAL<TFilter>
                where TFilter : BaseFilter
    {
        bool Any(TFilter filter);
    }

}
