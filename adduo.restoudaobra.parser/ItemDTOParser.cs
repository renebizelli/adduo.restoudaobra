using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.parser;

namespace adduo.restoudaobra.parser
{
    public class ItemDTOParser : BaseParser<ItemDTO>, IParser
    {
        public override void Parse(BaseResult result, BaseDto dto)
        {
            if (result != null)
            {
                var itemDTO = (ItemDTO)dto;

                var itemResult = (ItemResult)result;

                itemDTO.id = itemResult.id;
                itemDTO.Name = itemResult.Name;
            }
        }
    }
}
