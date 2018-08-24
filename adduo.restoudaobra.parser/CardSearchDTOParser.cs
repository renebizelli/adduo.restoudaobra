using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.parser
{
    public class CardSearchDTOParser : BaseParser<CardSearchDTO>, IParser
    {
        private AdImageDTOParser adImageDTOParser { get; set; }

        public CardSearchDTOParser(AdImageDTOParser adImageDTOParser)
        {
            this.adImageDTOParser = adImageDTOParser;
        }

        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result is SearchResult)
            {
                var cardSearchDTO = (CardSearchDTO)dto;

                var cardResult = (SearchResult)result;

                new AdDetailDTOParser().Parse(cardResult, cardSearchDTO.Ad);

                new AddressDetailDTOParser().Parse(cardResult, cardSearchDTO.Address);

                adImageDTOParser.Set(cardResult);

                var imageDTO = (AdImageDTO)adImageDTOParser.Get();

                cardSearchDTO.Image = imageDTO.Full;
            }
        }
    }
}
