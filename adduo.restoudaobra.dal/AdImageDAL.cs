using adduo.basetype.result;
using adduo.restoudaobra.dal.framework.database;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.parser;
using System.Linq;

namespace adduo.restoudaobra.dal
{
    public class AdImageDAL : BaseDAL<AdImageResult>, IAdImageDAL
    {
        public AdImageDTOParser adImageDTOParser { get; set; }

        public AdImageDAL(
            DapperFriendly dapper,
            AdImageDTOParser adImageDTOParser)
        {
            this.dapper = dapper;
            this.adImageDTOParser = adImageDTOParser;
        }

        public void Save(AdImageDTO dto)
        {
            var result = dapper
                .ResetParameter()
                .AddParameter("@GuidProduct", dto.GuidProduct)
                .AddParameter("@ImageFile", dto.File)
                .AddParameter("@idOwner", dto.idOwner)
                .AddParameter("@CreateAt", dto.CreateAt)
                .ExecuteWithOneResult<AdImageResult>("ad_image_register");

            adImageDTOParser.Parse(result, dto);
        }

        public void Delete(AdImageFilter filter)
        {
            dapper
                .ResetParameter()
                .AddParameter("@idOwner", filter.idOwner)
                .AddParameter("@id", filter.id)
                .Execute("ad_image_delete");
        }

        public void List(AdImageFilter filter, IParser parser)
        {
            var imageResults = dapper
                .ResetParameter()
                .AddParameter("@GuidProduct", filter.GuidProduct)
                .ExecuteWithManyResult<AdImageResult>("ad_image_get");

            parser.Set(imageResults.Cast<BaseResult>().ToList());
        }

        public void Get(AdImageFilter filter, IParser parser)
        {
            var imageResult = dapper
                .ResetParameter()
                .AddParameter("@idOwner", filter.idOwner)
                .AddParameter("@id", filter.id)
                .ExecuteWithOneResult<AdImageResult>("ad_image_get");

            parser.Set(imageResult);
        }

        public bool Any(AdImageFilter filter)
        {
            var any =
                dapper
                .ResetParameter()
                .AddParameter("@GuidProduct", filter.GuidProduct)
                .ExecuteWithBooleanResult("ad_image_any");

            return any;
        }

    }
}
