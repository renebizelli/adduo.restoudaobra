using adduo.basetype.dto;

namespace adduo.restoudaobra.ie.dal
{
    public interface ISaveDAL<TDto> where TDto : BaseDto
    {
        void Save(TDto dto);

    }
}
