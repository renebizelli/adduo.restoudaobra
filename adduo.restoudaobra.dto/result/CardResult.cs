using adduo.basetype.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adduo.restoudaobra.dto.result
{
    public class CardResult : BaseResult
    {
        public AdResult Ad { get; set; }
        public AddressResult Address { get; set; }
        public OwnerResult Owner { get; set; }
        public List<AdImageResult> Images { get; set; }
    }
}
