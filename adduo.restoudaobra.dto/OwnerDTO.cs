using adduo.basetype.dto;
using adduo.helper.property;
using adduo.restoudaobra.constants;
using Newtonsoft.Json;
using System;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class OwnerDTO : BaseDto
    {
        [JsonIgnore]
        public int id { get; set; }


        [JsonProperty("firstname")]
        public PropertyDtoString FirstName { get; set; }

        [JsonProperty("lastname")]
        public PropertyDtoString LastName { get; set; }

        [JsonProperty("email")]
        public PropertyDtoEmail Email { get; set; }

        [JsonProperty("emailconfirm")]
        public PropertyDtoEmail EmailConfirm { get; set; }


        [JsonProperty("cpf")]
        public PropertyDtoCPF Cpf { get; set; }

        [JsonProperty("phone")]
        public PropertyDtoPhone Phone { get; set; }

        [JsonProperty("cellphone")]
        public PropertyDtoPhone CellPhone { get; set; }

        [JsonProperty("password")]
        public PropertyDtoPassword Password { get; set; }

        [JsonProperty("passwordconfirm")]
        public PropertyDtoPassword PasswordConfirm { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("emailAccept")]
        public bool EmailAccept { get; set; }

        [JsonIgnore]
        public OWNER_STATUS Status { get; set; }

        [JsonIgnore]
        public DateTime Confirmated { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonIgnore]
        public PropertyDtoGuid Guid { get; set; }

        public OwnerDTO()
        {
            Guid = new PropertyDtoGuid();

            FirstName = new PropertyDtoString(32);
            LastName = new PropertyDtoString(64);
            Email = new PropertyDtoEmail();
            EmailConfirm = new PropertyDtoEmail();
            Phone = new PropertyDtoPhone();
            CellPhone = new PropertyDtoPhone();
            Cpf = new PropertyDtoCPF();
            PasswordConfirm = new PropertyDtoPassword();
            Password = new PropertyDtoPassword();


            AddPropertyToValidation(FirstName);
            AddPropertyToValidation(LastName);
            AddPropertyToValidation(Email);
            AddPropertyToValidation(Phone);
            AddPropertyToValidation(CellPhone);
        }

    }
}
