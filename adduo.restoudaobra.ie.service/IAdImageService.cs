using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using System;

namespace adduo.restoudaobra.ie.service
{
    public interface IAdImageService :
        ISaveService<AdImageDTO, AdImageDTO>,
        IDeleteService<AdImageDTO>,
        IListService<AdImageFilter>,
        IAnyService<AdImageFilter>
    {
        bool Validation(Guid guid);

    }
}

