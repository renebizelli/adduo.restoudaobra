using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.model;

namespace adduo.restoudaobra.service.emailhtml
{
    public class ContactEmailHtml : StructureEmailHtml
    {
        private ContactDTO dto { get; set; }

        public ContactEmailHtml(IAppSettings settings) : base(settings)
        {
        }

        public override void Create()
        {
            AddText(string.Format("Telefone: {0}", dto.Phone.Value));
            AddText(dto.Message.Value.Replace("\n", "<br />"));
        }

        public void Set(ContactDTO dto) {
            this.dto = dto;
        }
    }
}
