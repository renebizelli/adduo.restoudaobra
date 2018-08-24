using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace adduo.basetype.envelope
{
    [JsonObject]
    public class BaseResponse : BaseEnvelope
    {
    }

    [JsonObject]
    public class BaseResponse<T> : BaseResponse
    {
        [JsonProperty("dto")]
        public T Dto { get; set; }

        [JsonProperty("dtos")]
        public List<T> Dtos { get; set; }

        public BaseResponse(T dto)
        {
            Dto = dto;
            Dtos = new List<T>();
        }

        public void AddRange(List<T> dtos)
        {
            Dtos = dtos;
            Dto = Activator.CreateInstance<T>();
        }

        public void Add(T dto)
        {
            Dtos.Add(dto);
        }

        public BaseResponse()
        {
            Dto = Activator.CreateInstance<T>();
            Dtos = new List<T>();
        }

        public BaseResponse<TClone> Clone<TClone>() {
            return new BaseResponse<TClone>
            {
                Culture = this.Culture,
                Success = this.Success,
                Error = this.Error
            };
        }
    }

}
