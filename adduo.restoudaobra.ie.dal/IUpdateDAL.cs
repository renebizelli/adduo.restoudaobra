using adduo.basetype.dto;

namespace adduo.restoudaobra.ie.dal
{
    public interface IUpdate<TDto> where TDto : BaseDto
    {
        void Update(TDto dto);

    }
}
