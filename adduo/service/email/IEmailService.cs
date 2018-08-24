using System;
using System.Collections.Generic;
using System.Text;

namespace adduo.service.email
{
    public interface IEmailService
    {
        void Send(EmailDTO dto);
    }
}
