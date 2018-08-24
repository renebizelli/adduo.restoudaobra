using adduo.restoudaobra.dto.filter;

namespace adduo.restoudaobra.ie.service
{
    public interface IOwnerService :
        IGetService<OwnerFilter>
    {
        bool Already(OwnerFilter filter);
    }
}
