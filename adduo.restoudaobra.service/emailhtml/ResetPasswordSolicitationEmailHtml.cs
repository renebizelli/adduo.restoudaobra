using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.model;
using System;

namespace adduo.restoudaobra.service.emailhtml
{
    public class ResetPasswordSolicitationEmailHtml : StructureEmailHtml
    {
        private OwnerDTO dto { get; set; }
        private Guid key { get; set; }

        public void Set(OwnerDTO dto, Guid key)
        {
            this.dto = dto;
            this.key = key;
        }

        public ResetPasswordSolicitationEmailHtml(IAppSettings settings) : base(settings)
        {

        }

        public override void Create()
        {
            AddHeader();
            AddName(dto.FirstName.Value);
            AddText(@"Você solicitou a redefinição da senha. Para continuar, clique no link ""Redefinir Senha"" a seguir.");
            AddLink("Redefinir Senha", string.Format("{0}/conta/redefinir-senha/{1}", settings.PathHost, key.ToString()));
            Signature();
        }

    }
}
