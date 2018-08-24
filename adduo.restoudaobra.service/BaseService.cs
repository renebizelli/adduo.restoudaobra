using adduo.restoudaobra.ie.model;
using adduo.service.email;

namespace adduo.restoudaobra.service
{
    public class BaseService
    {
        public IEmailService emailService { get; set; }
        public IAppSettings settings { get; set; }
    }
}
