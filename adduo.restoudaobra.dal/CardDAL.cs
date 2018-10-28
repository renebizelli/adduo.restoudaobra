using adduo.basetype.result;
using adduo.restoudaobra.dal.framework.database;
using adduo.restoudaobra.dal.framework.extractor;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adduo.restoudaobra.dal
{
    public class CardDAL : BaseDAL<BaseResult>, ICardDAL
    {
        public CardDAL(DapperFriendly dapper, IConfiguration configuration)
        {
            this.dapper = dapper;
            this.configuration = configuration;
        }

        public void Get(AdFilter filter, IParser parser)
        {
            List(filter, parser);
        }

        public void IncrementContactView(Guid guid)
        {
            dapper
                .ResetParameter()
                .AddParameter("@guid", guid)
                .Execute("card_view");
        }

        public void List(AdFilter filter, IParser parser)
        {
            var cards = new List<CardResult>();

            var extractor = new CardsMultiResultExtractor(cards);

            dapper
                .ResetParameter()
                .AddParameter("@id", filter.id)
                .AddParameter("@guid", filter.Guid)
                .AddParameter("@idOwner", filter.idOwner)
                .AddParameter("@adStatusList", filter.StringStatusList)
                .AddParameter("@ownerStatusActive", filter.idOwnerStatus)
                .ExecuteMultiple("card_get", extractor);

            parser.Set(cards.Cast<BaseResult>().ToList());
        }
    }
}
