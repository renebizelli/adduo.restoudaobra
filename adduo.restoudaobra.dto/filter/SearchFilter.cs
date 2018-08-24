using adduo.basetype.filter;
using adduo.restoudaobra.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adduo.restoudaobra.dto.filter
{
    public class SearchFilter : BaseFilter
    {
        public string Term { get; set; }
        public AD_STATUS AdStatus { get; set; }
        public OWNER_STATUS OwnerStatus { get; set; }

        public int idStatusAd { get { return (int)AdStatus; } }
        public int idStatusOwner { get { return (int)OwnerStatus; } }
    }
}
