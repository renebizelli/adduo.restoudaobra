using adduo.restoudaobra.ie.model;

namespace adduo.restoudaobra.service.emailhtml
{
    public class InviteROEmailHtml : StructureEmailHtml
    {
        private string name { get; set; }

        public InviteROEmailHtml(IAppSettings settings) : base(settings)
        {

        }

        public void Set(string name) {
            this.name = name;
        }

        public override void Create()
        {
            AddHeader();
            Break();
            AddName(name);
            AddText("Estamos desenvolvendo um site que ajuda as pessoas a darem um fim útil aos excessos de materias de construção. Sabe aquele monte de tijolos que só usaram a metade? ou meio saco de cimento.. azulejos, etc... ");
            AddText("Pois bem, isso pode ser muito útil para outras pessoas que também estão em obra.");
            AddText("Estamos na reta final do desenvolvimento e gostariamos da sua ajuda para testa-lo. Se recebeu este e-mail, é porque confiamos em você. :)");
            AddText("A ideia é que você entre no site, se cadastre e depois crie um anúncio, mesmo que fictício de qualquer material.Se você tiver mesmo algum material que queira se desfazer, melhor ainda!");
            AddText("O endereço do site é <a href='http://www.restoudaobra.com.br' target='_blank'>www.restoudaobra.com.br</a>");
            AddText("Seu cadastro já vai nos ajudar bastante, mas se quiser nos contar como foi sua experiência, vamos adorar saber :)");
            Break();
            AddText("Muito obrigado");
            AddText("René Bizelli e Eduardo Moreno");
        }
    }
}
