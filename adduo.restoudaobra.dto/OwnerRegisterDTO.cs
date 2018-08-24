namespace adduo.restoudaobra.dto
{
    public class OwnerRegisterDTO : OwnerDTO
    {
        public OwnerRegisterDTO()
        {
            AddPropertyToValidation(Cpf);
            AddPropertyToValidation(Password);
            AddPropertyToValidation(PasswordConfirm);
            AddPropertyToValidation(EmailConfirm);
        }

    }
}
