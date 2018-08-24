using adduo.basetype.result;
using adduo.restoudaobra.dal.framework.database;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.parser;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adduo.restoudaobra.dal
{
    public class AddressDAL : BaseDAL<AddressResult>, IAddressDAL
    {
        private IParser addressRegisterDTOParser { get; set; }

        public AddressDAL(IConfiguration configuration, DapperFriendly dapper, AddressRegisterDTOParser addressRegisterDTOParser)
        {
            this.dapper = dapper;
            this.addressRegisterDTOParser = addressRegisterDTOParser;
        }

        public void Save(AddressRegisterDTO addressDTO)
        {
            var procedure = dapper
                .ResetParameter()
                .AddParameter("@id", addressDTO.id)
                .AddParameter("@City", addressDTO.City)
                .AddParameter("@District", addressDTO.District)
                .AddParameter("@idState", addressDTO.State)
                .AddParameter("@idOwner", addressDTO.idOwner);

            if (addressDTO.id.Value.Equals(0))
            {
                procedure.AddParameter("@Created", DateTime.Now);
            }
            else
            {
                procedure.AddParameterNullValue("@Created");
            }

            var addressResult = procedure.ExecuteWithOneResult<AddressResult>("address_register");

            addressRegisterDTOParser.Parse(addressResult, addressDTO);
        }

        public void Get(AddressFilter filter, IParser parser)
        {
            var addressResult = new AddressResult();

            if (!filter.IsEmpty())
            {
                addressResult = dapper
                                .ResetParameter()
                                .AddParameter("@id", filter.id)
                                .AddParameter("@idOwner", filter.idOwner)
                                .ExecuteWithOneResult<AddressResult>("address_get");

                parser.Set(addressResult);
            }
        }

        public void List(AddressFilter filter, IParser parser)
        {
            var response = new List<AddressRegisterDTO>();
            var addressesResult = new List<AddressResult>();

            if (!filter.IsEmpty())
            {
                addressesResult = dapper
                                .ResetParameter()
                                .AddParameter("@id", filter.id)
                                .AddParameter("@idOwner", filter.idOwner)
                                .ExecuteWithManyResult<AddressResult>("address_get");

                parser.Set(addressesResult.Cast<BaseResult>().ToList());
            }
        }
    }
}
