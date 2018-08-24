using adduo.basetype.filter;
using adduo.helper.hash;
using adduo.methodextension;
using adduo.restoudaobra.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adduo.restoudaobra.dto.filter
{
    public class OwnerFilter : BaseFilter
    {
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RedefinePasswordKey { get; set; }

        public string PasswordHash
        {
            get
            {
                return HashHelper.HashSHA512(Password);
            }
        }


        public OWNER_STATUS Status { get; set; }

        public override bool IsEmpty()
        {
            return base.IsEmpty() &&
                   CPF.IsNullOrEmpty() &&
                   Email.IsNullOrEmpty() &&
                   Password.IsNullOrEmpty() &&
                   Guid.IsEmpty() &&
                   Status.Equals(OWNER_STATUS.NONE) &&
                   RedefinePasswordKey.IsEmpty();

        }
    }
}
