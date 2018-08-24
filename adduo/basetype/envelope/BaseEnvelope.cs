using adduo.helper.property;
using Newtonsoft.Json;
using System;

namespace adduo.basetype.envelope
{
    public class BaseEnvelope
    {
        [JsonProperty("culture")]
        public string Culture { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public ErrorEnvelope Error { get; set; }

        public BaseEnvelope()
        {
            Error = new ErrorEnvelope();
        }

        public void ThrownIfError(string code = null)
        {
            if (Error != null)
            {
                if (Error.Code.Equals(0))
                {
                    throw new Exception(((ERROR_CODE)Error.Code).ToString());
                }
            }

            if (!Success)
            {
                throw new Exception(code);
            }
        }

    }
}
