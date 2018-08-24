using adduo.restoudaobra.ie.model;

namespace adduo.restoudaobra.dto.model
{
    public class AppSettings : IAppSettings
    {
        public string EmailContact { get; set; }
        public string PathHost { get; set; }
        public string PathAdImage { get; set; }
    }
}
