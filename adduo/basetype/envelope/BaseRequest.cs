using adduo.basetype.dto;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace adduo.basetype.envelope
{
    [JsonObject]
    public class BaseRequest : BaseEnvelope
    {
        [JsonProperty("autocloseloader")]
        public bool AutoCloseLoader { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }
    }

    [JsonObject]
    public class BaseRequest<T> : BaseRequest
        where T : BaseDto
    {
        [JsonProperty("dto")]
        public T Dto { get; set; }

        [JsonProperty("dtos")]
        public List<T> Dtos { get; set; }

        public BaseRequest()
        {
            Dtos = new List<T>();
        }

        public BaseRequest(T _dto)
        {
            Dto = _dto;
            Dtos = new List<T>();
        }

        public BaseResponse<T> CreateResponse() {

            var response = new BaseResponse<T>();

            response.Dto = this.Dto;
            response.Dtos = this.Dtos;

            response.Culture = this.Culture;
            response.Error = this.Error;
            response.Success = this.Success;

            return response;

        }

    }

}
