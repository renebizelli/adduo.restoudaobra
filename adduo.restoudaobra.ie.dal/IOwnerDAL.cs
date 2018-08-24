using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using System;

namespace adduo.restoudaobra.ie.dal
{
    public interface IOwnerDAL :
        ISaveDAL<OwnerDTO>,
        IUpdate<OwnerDTO>,
        IGetDAL<OwnerFilter>,
        IDeleteDAL<OwnerFilter>
    {
        bool Already(OwnerFilter filter);
        void Confirmation(OwnerDTO dto);

    }
}
