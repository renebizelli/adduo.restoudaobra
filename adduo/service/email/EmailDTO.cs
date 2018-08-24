

namespace adduo.service.email
{
    public class EmailDTO
    {
        public EmailAccountDTO From { get; set; }
        public EmailAccountDTO Replay { get; set; }
        public EmailAccountDTO To { get; set; }
        public string Subject { get; set; }
        public IEmailHtml EmailHtml { get; set; }

        public EmailDTO()
        {
            From = new EmailAccountDTO();
            To = new EmailAccountDTO();
        }
    }

}
