using adduo.basetype.result;
using System;

namespace adduo.restoudaobra.dto.result
{
    public class AddressResult : BaseResult
    {
        public int id { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public int idState { get; set; }
        public string StateName { get; set; }

        public int idOwner { get; set; }
        public string OwnerName { get; set; }

        public DateTime Created { get; set; }
    }
}
