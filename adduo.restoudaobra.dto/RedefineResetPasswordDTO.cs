using adduo.basetype.dto;
using System;

namespace adduo.restoudaobra.dto
{
    public class RedefineResetPasswordDTO : BaseDto
    {
        public RedefineResetPasswordDTO(int id, Guid key)
        {
            this.key = key;
            this.id = id;
            this.Created = DateTime.Now;
        }

        public Guid key { get; set; }

        public int id { get; set; }

        public DateTime Created { get; set; }

    }
}
