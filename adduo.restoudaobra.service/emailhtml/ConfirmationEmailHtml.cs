using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.model;

namespace adduo.restoudaobra.service.emailhtml
{
    public class ConfirmationEmailHtml : StructureEmailHtml
    {
        public OwnerDTO dto { get; set; }

        public ConfirmationEmailHtml(IAppSettings settings) : base(settings)
        {
        }

        public override void Create()
        {
            AddHeader();
            AddName(dto.FirstName.Value);
            AddText(@"Seu cadastro está quase concluído. Você precisa apenas clicar no link ""Confirmar"" e pronto :)");
            AddLink("Confirmar", string.Format("{0}/conta/confirmacao/{1}", settings.PathHost, dto.Guid.Value));
            Signature();
        }

        public void Set(OwnerDTO dto)
        {
            this.dto = dto;
        }


    }
}
