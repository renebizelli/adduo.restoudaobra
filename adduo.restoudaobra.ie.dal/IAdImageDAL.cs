using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;

namespace adduo.restoudaobra.ie.dal
{
    public interface IAdImageDAL :
            IDeleteDAL<AdImageFilter>,
            IListDAL<AdImageFilter>,
            IGetDAL<AdImageFilter>,
            IAnyDAL<AdImageFilter>
    {
        void Save(AdImageDTO dto);
    }
}
