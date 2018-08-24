using adduo.basetype.result;
using System;

namespace adduo.restoudaobra.dto.result
{
    public class AdImageResult : BaseResult
    {
        public int id { get; set; }
        public Guid GuidProduct { get; set; }
        public string ImageFile { get; set; }
    }
}
