using adduo.basetype.dto;
using adduo.basetype.result;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adduo.restoudaobra.parser
{
    public abstract class BaseParser<TDto> where TDto : BaseDto
    {
        public List<BaseResult> results { get; set; }

        public BaseParser()
        {
            results = new List<BaseResult>();
        }

        public abstract void Parse(BaseResult result, BaseDto dto);

        public List<BaseDto> List()
        {
            var dtos = new List<BaseDto>();

            foreach (var result in this.results)
            {
                var dto = Activator.CreateInstance<TDto>();

                Parse(result, dto);

                dtos.Add(dto);
            }

            return dtos;
        }

        public BaseDto Get()
        {
            TDto dto = null;

            if (results.Any())
            {
                dto = Activator.CreateInstance<TDto>();
                Parse(this.results.First(), dto);
            }

            return dto;
        }

        public void Set(BaseResult result)
        {
            this.results.Add(result);
        }

        public void Set(IEnumerable<BaseResult> results)
        {
            this.results = results.ToList();
        }

    }
}
