namespace adduo.restoudaobra.ie.providers
{
    public interface ITokenConfigurations
    {
        string Audience { get; set; }
        string Issuer { get; set; }
        int Seconds { get; set; }
    }

}
