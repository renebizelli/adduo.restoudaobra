using adduo.restoudaobra.dal.framework.database;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.dal;
using Microsoft.Extensions.Configuration;

namespace adduo.restoudaobra.dal
{
    public class RedefinePasswordDAL : BaseDAL<OwnerResult>, IRefefinePasswordDAL
    {
        public RedefinePasswordDAL(DapperFriendly dapper, IConfiguration configuration)
        {
            this.dapper = dapper;
            this.configuration = configuration;
        }


        public void Save(RedefineResetPasswordDTO dto)
        {
            var result =
                dapper
                .ResetParameter()
                .AddParameter("@idOwner", dto.id)
                .AddParameter("@key", dto.key)
                .AddParameter("@Created", dto.Created)
                .Execute("redefine_password_register");
        }

        public void Delete(OwnerFilter filter)
        {
            var result =
                dapper
                .ResetParameter()
                .AddParameter("@idOwner", filter.idOwner)
                .Execute("redefine_password_delete");
        }

        public void ChangePassword(RedefinePasswordChangeDTO changePasswordDTO)
        {
            var result = 
                dapper
                .ResetParameter()
                .AddParameter("@id", changePasswordDTO.id)
                .AddParameter("@Password", changePasswordDTO.Password.Hash)
                .Execute("redefine_password_change");
        }
    }
}
