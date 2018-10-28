using adduo.basetype.result;
using System;

namespace adduo.restoudaobra.dto.result
{
    public class AdResult : BaseResult
    {
        public int id { get; set; }
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Option { get; set; }

        public string Brand { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime Created { get; set; }

        public int idType { get; set; }
        public string TypeName { get; set; }

        public int idStatus { get; set; }

        public string StatusName { get; set; }

        public int idOwner { get; set; }

        public int idAddress { get; set; }

        public int ViewContact { get; set; }

    }
}
