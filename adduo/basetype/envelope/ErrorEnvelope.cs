using adduo.helper.property;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adduo.basetype.envelope
{
    [JsonObject]
    public class ErrorEnvelope
    {
        [JsonProperty("messages")]
        public List<string> Messages { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, string> Fields { get; set; }

        [JsonIgnore] 
        public Exception Exception { get; set; }

        [JsonIgnore]
        public bool HasError { get { return Messages.Any(); } }

        [JsonProperty("code")]
        public ERROR_CODE Code { get; set; }

        public ErrorEnvelope()
        {
            Messages = new List<string>();
            Fields = new Dictionary<string, string>();
        }
    }
}
