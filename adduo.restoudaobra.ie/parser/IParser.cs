using adduo.basetype.dto;
using adduo.basetype.result;
using System.Collections.Generic;

namespace adduo.restoudaobra.ie.parser
{
    public interface IParser
    {
        void Set(BaseResult result);
        BaseDto Get();
        void Set(IEnumerable<BaseResult> result);
        List<BaseDto> List();
        void Parse(BaseResult result, BaseDto dto);
    }
}
