using adduo.helper.property;
using adduo.methodextension;
using adduo.restoudaobra.dal.framework.database;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.parser;
using Microsoft.Extensions.Configuration;
using System;

namespace adduo.restoudaobra.dal
{
    public class OwnerDAL : BaseDAL<OwnerResult>, IOwnerDAL
    {
        public OwnerDAL(DapperFriendly dapper, IConfiguration configuration)
        {
            this.dapper = dapper;
            this.configuration = configuration;
        }

        public void Save(OwnerDTO ownerDTO)
        {
            if (ownerDTO.id.Equals(0))
            {
                ownerDTO.Guid = new PropertyDtoGuid(true);
                ownerDTO.Created = DateTime.Now;
                ownerDTO.Confirmated = DateTime.Now;
            }

            var result =
                dapper
                .ResetParameter()
                .AddParameter("@Guid", ownerDTO.Guid)
                .AddParameter("@FirstName", ownerDTO.FirstName)
                .AddParameter("@LastName", ownerDTO.LastName)
                .AddParameter("@Email", ownerDTO.Email)
                .AddParameter("@Cpf", ownerDTO.Cpf.Value.OnlyNumber())
                .AddParameter("@Phone", ownerDTO.Phone.Value.OnlyNumber())
                .AddParameter("@CellPhone", ownerDTO.CellPhone.Value.OnlyNumber())
                .AddParameter("@Password", ownerDTO.Password.Hash)
                .AddParameter("@Created", ownerDTO.Created)
                .AddParameter("@Confirmated", ownerDTO.Confirmated)
                .AddParameter("@idStatus", (int)ownerDTO.Status)
                .ExecuteWithOneResult<OwnerResult>("owner_register");

            var parser = new OwnerDTOParser();

            parser.Parse(result, ownerDTO);
        }

        public void Update(OwnerDTO ownerDTO)
        {
            var ownerResult =
                dapper
                .ResetParameter()
                .AddParameter("@id", ownerDTO.id)
                .AddParameter("@FirstName", ownerDTO.FirstName)
                .AddParameter("@LastName", ownerDTO.LastName)
                .AddParameter("@Email", ownerDTO.Email)
                .AddParameter("@Phone", ownerDTO.Phone.Value.OnlyNumber())
                .AddParameter("@CellPhone", ownerDTO.CellPhone.Value.OnlyNumber())
                .ExecuteWithOneResult<OwnerResult>("owner_update");

            var parser = new OwnerDTOParser();
            parser.Parse(ownerResult, ownerDTO);
        }

        public void Confirmation(OwnerDTO ownerDTO)
        {
            var procedure =
                dapper
                .ResetParameter()
                .AddParameter("@Guid", ownerDTO.Guid)
                .AddParameter("@idStatus", (int)ownerDTO.Status)
                .AddParameter("@Confirmated", ownerDTO.Confirmated)
                .Execute("owner_confirmation");
        }

        public bool Already(OwnerFilter filter)
        {
            var already =
                dapper
                .ResetParameter()
                .AddParameter("@idOwner", filter.idOwner)
                .AddParameter("@Guid", filter.Guid)
                .AddParameter("@Email", filter.Email)
                .AddParameter("@CPF", filter.CPF.OnlyNumber())
                .ExecuteWithBooleanResult("owner_any");

            return already;
        }

        public void Delete(OwnerFilter filter)
        {
            dapper
                .ResetParameter()
               .AddParameter("@Guid", filter.Guid)
               .Execute("owner_delete");
        }


        public void Get(OwnerFilter filter, IParser parser)
        {
            if (!filter.IsEmpty())
            {
                var ownerResult =
                    dapper
                    .ResetParameter()
                    .AddParameter("@idOwner", filter.idOwner)
                    .AddParameter("@Guid", filter.Guid)
                    .AddParameter("@Email", filter.Email)
                    .AddParameter("@CPF", filter.CPF)
                    .AddParameter("@PasswordHash", filter.PasswordHash)
                    .AddParameter("@RedefinePasswordKey", filter.RedefinePasswordKey)
                    .ExecuteWithOneResult<OwnerResult>("owner_get");

                if (ownerResult != null)
                {
                    parser.Set(ownerResult);
                }
            }
        }
    }
}
