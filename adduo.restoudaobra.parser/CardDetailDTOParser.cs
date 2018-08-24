using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.parser;
using System.Linq;

namespace adduo.restoudaobra.parser
{
    public class CardDetailDTOParser : BaseParser<CardDetailDTO>, IParser
    {
        private AdImageDTOParser adImageDTOParser { get; set; }

        public CardDetailDTOParser(AdImageDTOParser adImageDTOParser)
        {
            this.adImageDTOParser = adImageDTOParser;
        }

        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result is CardResult)
            {
                var cardDetailDTO = (CardDetailDTO)dto;

                var cardResult = (CardResult)result;

                new AdDetailDTOParser().Parse(cardResult.Ad, cardDetailDTO.Ad);

                new AddressDetailDTOParser().Parse(cardResult.Address, cardDetailDTO.Address);

                new OwnerDetailDTOParser().Parse(cardResult.Owner, cardDetailDTO.Owner);

                adImageDTOParser.Set(cardResult.Images.Cast<BaseResult>().ToList());

                cardDetailDTO.Images = adImageDTOParser.List()
                                            .Cast<AdImageDTO>()
                                            .Select(S => S.Full)
                                            .ToList();
            }
        }
    }
}
