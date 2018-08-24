using adduo.basetype.result;
using System;

namespace adduo.restoudaobra.dto.result
{
    public class OwnerResult : BaseResult
    {
        public int id { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Confirmated { get; set; }
        public int idStatus { get; set; }
        public string StatusName { get; set; }
    }
}
