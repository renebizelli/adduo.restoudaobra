using adduo.basetype.filter;

namespace adduo.restoudaobra.ie.dal
{
    public interface IDeleteDAL<TFilter>
    where TFilter : BaseFilter
    {
        void Delete(TFilter filter);
    }

}
