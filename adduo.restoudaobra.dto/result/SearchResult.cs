using adduo.basetype.result;
using System;

namespace adduo.restoudaobra.dto.result
{
    public class SearchResult : BaseResult
    {
        public Guid ProductGuid { get; set; }

        public string ProductName { get; set; }

        public string ProductBrand { get; set; }

        public string ProductQuantity { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductType { get; set; }

        public int ProductViewContact { get; set; }

        public string AddressDistrict { get; set; }
        public string AddressCity { get; set; }
        public string AddressStateName { get; set; }

        public string ImageFile { get; set; }
    }
}
