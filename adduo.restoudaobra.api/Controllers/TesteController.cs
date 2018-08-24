using adduo.helper.property;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.service.emailhtml;
using adduo.service.email;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    public class TesteController : BaseApiController
    {
        private IEmailService emailService { get; set; }

        public TesteController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpGet]
        [Route("teste/email")]
        public string Email(IAppSettings settings) 
        {
            var msg = string.Empty;


            try
            {
                emailService.Send(new EmailDTO
                {
                    To = new EmailAccountDTO { Email = "forum@listroman.com.br", Name = "Teste " + DateTime.Now.Millisecond.ToString() },
                    EmailHtml = new StructureEmailHtml(settings),
                    Subject = "Teste + " + DateTime.Now.Millisecond.ToString()
                });
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }


        [HttpPost]
        [Route("teste/teste")]
        public ObjectResult Test([FromBody] Teste teste)
        {
            return StatusCode(200, teste.Name);
        }

    }

    [JsonObject]
    public class Teste
    {
        [JsonProperty("name")]
        public PropertyDtoString Name { get; set; }

        public Teste()
        {
            Name = new PropertyDtoString(99);
        }

    }
}
