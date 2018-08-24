using System;

namespace adduo.basetype.exception
{
    public class ViolationBusinessException : Exception
    {
        public int id { get; set; }

        public ViolationBusinessException(int id, string message) : base(message)
        {
            this.id = id;
        }
    }
}
