using adduo.restoudaobra.dal.framework.database;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.parser;
using Microsoft.Extensions.Configuration;
using System;

namespace adduo.restoudaobra.dal
{
    public class AdDAL : BaseDAL<AdResult>, IAdDAL
    {
        public AdDAL(DapperFriendly dapper, IConfiguration configuration)
        {
            this.dapper = dapper;
            this.configuration = configuration;
        }

        public void Save(AdRegisterDTO dto)
        {
            if (dto.id.Equals(0))
            {
                dto.Created = DateTime.Now;
            }

            var result = new AdResult();

            var parameters = dapper
                .ResetParameter()
                .AddParameter("@id", dto.id)
                .AddParameter("@Guid", dto.Guid)
                .AddParameter("@Name", dto.Name)
                .AddParameter("@Brand", dto.Brand)
                .AddParameter("@Option", dto.Option)
                .AddParameter("@Quantity", dto.Quantity)
                .AddParameter("@Price", dto.Price)
                .AddParameter("@Created", dto.Created)
                .AddParameter("@idType", (int)dto.Type)
                .AddParameter("@idStatus", (int)dto.Status)
                .AddParameter("@idOwner", dto.idOwner)
                .AddParameter("@idAddress", dto.idAddress);

            if (dto.id.Equals(0))
            {
                result = parameters.ExecuteWithOneResult<AdResult>("ad_register");
            }
            else
            {
                result = parameters.ExecuteWithOneResult<AdResult>("ad_update");
            }

            var parser = new AdRegisterDTOParser();

            parser.Parse(result, dto);
        }

        public void ChangeStatus(AdChangeStatusDTO dto)
        {
            var result = dapper
                .ResetParameter()
                .AddParameter("@guid", dto.guid)
                .AddParameter("@idOwner", dto.idOwner)
                .AddParameter("@idStatus", (int)dto.Status)
                .Execute("ad_change_status");
        }
    }
}
