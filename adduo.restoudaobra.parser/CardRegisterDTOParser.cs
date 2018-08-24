using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.helper.property;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.ie.parser;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace adduo.restoudaobra.parser
{
    public class CardRegisterDTOParser : BaseParser<CardRegisterDTO>, IParser
    {
        private AdImageDTOParser adImageDTOParser { get; set; }

        public CardRegisterDTOParser(AdImageDTOParser adImageDTOParser)
        {
            this.adImageDTOParser = adImageDTOParser;
        }

        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result is CardResult)
            {
                var cardRegisterDTO = (CardRegisterDTO)dto;

                var cardResult = (CardResult)result;

                new AdRegisterDTOParser().Parse(cardResult.Ad, cardRegisterDTO.Ad);

                new AddressRegisterDTOParser().Parse(cardResult.Address, cardRegisterDTO.Address);

                adImageDTOParser.Set(cardResult.Images.Cast<BaseResult>().ToList());

                var images = adImageDTOParser.List()
                                            .Cast<AdImageDTO>()
                                            .ToList();

                cardRegisterDTO.Images = new PropertyListDto<AdImageDTO>()
                {
                    List = new List<AdImageDTO>()
                };

                var i = 0;
                foreach (var image in images)
                {
                    cardRegisterDTO.Images.List.Add(new AdImageDTO
                    {
                        Full = image.Full,
                        GuidProduct = cardResult.Ad.Guid,
                        Index = i++,
                        id = image.id
                    });
                }
            }
        }
    }
}
