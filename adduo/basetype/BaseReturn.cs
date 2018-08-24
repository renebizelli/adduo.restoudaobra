using System.Collections.Generic;

namespace adduo.basetype
{
    public class BaseReturn
    {
        private bool ok { get; set; }

        public Dictionary<string, string> message { get; private set; }

        public BaseReturn()
        {
            message = new Dictionary<string, string>();
        }

        public void AddMessage(string key, string description)
        {
            message[key] = description;
        }

        public void Ok()
        {
            ok = true;
        }

        public bool IsOk() => ok;
    }
}
