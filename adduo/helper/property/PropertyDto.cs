using adduo.basetype.dto;
using adduo.helper.hash;
using adduo.helper.property.validation;
using adduo.methodextension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace adduo.helper.property
{

    [JsonObject]
    public class PropertyDto : BaseDto
    {
        [JsonProperty("status")]
        public PROPERTY_STATUS Status { get; set; }

        [JsonProperty("code")]
        public ERROR_CODE Code { get; set; }

        [JsonProperty("edit")]
        public bool Edit { get; set; }

        [JsonProperty("prop")]
        public bool Prop { get { return true; } }

        public void Reset()
        {
            Status = PROPERTY_STATUS.NONE;
            Code = ERROR_CODE.NONE;
        }

        public bool IsValid()
        {
            return Status == PROPERTY_STATUS.VALID;
        }

        public bool IsInvalid()
        {
            return Status == PROPERTY_STATUS.INVALID;
        }

        public bool IsInvalidOrEmpty()
        {
            return Status == PROPERTY_STATUS.INVALID || Status == PROPERTY_STATUS.NONE;
        }


        public bool IsEmpty()
        {
            return Status == PROPERTY_STATUS.NONE;
        }


        public virtual bool Validate() { return true; }

    }

    [JsonObject]
    public class PropertyDto<T> : PropertyDto, IPropertyDto<T>
    {
        [JsonProperty("value")]
        public T Value { get; set; }

        [JsonProperty("defaultvalue")]
        public T DefaultValue { get; set; }

        private List<IPropertyDtoValidation<T>> Validations { get; set; }

        public PropertyDto()
        {
            Validations = new List<IPropertyDtoValidation<T>>();
        }

        public void AddValidation(IPropertyDtoValidation<T> validation)
        {
            validation.Set(this);

            Validations.Add(validation);
        }

        public override bool Validate()
        {
            foreach (var validation in Validations)
            {
                validation.Validate();
            }

            return true;
        }
    }

    [JsonObject]
    public class PropertyDtoString : PropertyDto<string>
    {
        [JsonProperty("maxlength")]
        public int MaxLength { get; set; }

        public PropertyDtoString(int maxlength)
        {
            MaxLength = maxlength;
            AddValidation(new PropertyDtoNotEmptyValidation());
        }
    }

    [JsonObject]
    public class PropertyDtoItem : PropertyDto<ItemDTO>
    {
        public PropertyDtoItem()
        {
            AddValidation(new PropertyDtoItemEmptyValidation());
        }
    }


    [JsonObject]
    public class PropertyDtoText : PropertyDto<string>
    {
        public PropertyDtoText()
        {
            AddValidation(new PropertyDtoNotEmptyValidation());
        }
    }

    [JsonObject]
    public abstract class PropertyDtoFormat : PropertyDtoString
    {
        public PropertyDtoFormat(int maxlength) : base(maxlength)
        {

        }

        [JsonProperty("formatted")]
        public string Formatted { get { return Format(); } }

        public virtual string Format()
        {
            return Value;
        }
    }

    [JsonObject]
    public class PropertyDtoPhone : PropertyDtoFormat
    {
        public PropertyDtoPhone() : base(16)
        {
            AddValidation(new PropertyDtoPhoneValidation());

        }

        public override string Format()
        {
            return this.PhoneFormat();
        }
    }

    [JsonObject]
    public class PropertyDtoCPF : PropertyDtoFormat
    {
        public PropertyDtoCPF() : base(11)
        {
            AddValidation(new PropertyDtoCPFValidation());
        }

        public override string Format()
        {
            return this.CPFFormat();
        }
    }

    [JsonObject]
    public class PropertyDtoEmail : PropertyDtoString
    {
        public PropertyDtoEmail() : base(128)
        {
            AddValidation(new PropertyDtoEmailValidation());
        }
    }

    [JsonObject]
    public class PropertyDtoPassword : PropertyDtoString
    {
        [JsonIgnore]
        public string Hash
        {
            get
            {
                return HashHelper.HashSHA512(this.Value);
            }
        }

        public PropertyDtoPassword() : base(255)
        {

        }

        public void Clear()
        {
            this.Value = string.Empty;
        }
    }



    [JsonObject]
    public class PropertyDtoGuid : PropertyDto<Guid>
    {
        public PropertyDtoGuid(bool newGuid)
        {
            Value = Guid.Empty;

            if (newGuid)
            {
                Value = Guid.NewGuid();
            }
        }

        public PropertyDtoGuid()
        {
            Value = Guid.Empty;
        }
    }

    [JsonObject]
    public class PropertyDtoInt : PropertyDto<int>
    {
        public PropertyDtoInt()
        {
            AddValidation(new PropertyDtoIntNotZeroValidation());
        }
    }

    [JsonObject]
    public class PropertyDtoDecimal : PropertyDto<decimal>
    {
        public PropertyDtoDecimal()
        {
            AddValidation(new PropertyDtoDecimalNotZeroValidation());
        }
    }


}
