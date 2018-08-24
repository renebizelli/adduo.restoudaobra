namespace adduo.restoudaobra.ie.model
{
    public interface IAppSettings
    {
        string EmailContact { get; set; }
        string PathHost { get; set; }
        string PathAdImage { get; set; }
    }

    public interface ISettingsEmailModel
    {
        string Contact { get; set; }
    }

    public interface ISettingsPathModel
    {
        string Host { get; set; }
        string AdImage { get; set; }
    }
}
