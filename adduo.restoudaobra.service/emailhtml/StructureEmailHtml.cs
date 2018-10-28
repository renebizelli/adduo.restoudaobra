using adduo.restoudaobra.ie.model;
using adduo.service.email;
using System.Text;

namespace adduo.restoudaobra.service.emailhtml
{
    public class StructureEmailHtml : IEmailHtml
    {
        private StringBuilder html { get; set; }
        private StringBuilder contentHtml { get; set; }
        private StringBuilder headerHtml { get; set; }
        public IAppSettings settings { get; set; }

        public virtual void Create() { }

        public StructureEmailHtml(IAppSettings settings)
        {
            this.settings = settings;

            html = new StringBuilder();
            contentHtml = new StringBuilder();
            headerHtml = new StringBuilder();
        }

        public void AddHeader()
        {
            headerHtml = new StringBuilder();
            headerHtml.Append("<tr>");
            headerHtml.Append("<td>");
            headerHtml.AppendFormat("<img src='{0}/assets/_img/restou-da-obra-logo-1.png' border='0' />", settings.PathHost);
            headerHtml.Append("</td>");
            headerHtml.Append("</tr>");
        }

        public string Html()
        {
            html.Append("<html>");
            html.Append("<head>");
            html.Append("</head>");
            html.Append("<body  style='width:380px'>");
            html.Append("<table>");
            html.Append(headerHtml);
            html.Append("<tr>");
            html.Append("<td>");
            html.Append("<table cellpadding=5 cellspacing=5>");
            html.Append(contentHtml);
            html.Append("</table>");
            html.Append("</td>");
            html.Append("</tr>");
            html.Append("</table>");
            html.Append("</body>");
            html.Append("</html>");

            return html.ToString();
        }

        public void AddName(string name)
        {
            contentHtml.Append("<tr>");
            contentHtml.Append("<td>");
            Text($"Olá {name}!");
            contentHtml.Append("</td>");
            contentHtml.Append("</tr>");
        }

        public void AddText(string text)
        {
            contentHtml.Append("<tr>");
            contentHtml.Append("<td>");
            Text(text);
            contentHtml.Append("</td>");
            contentHtml.Append("</tr>");
        }


        public void Break()
        {
            contentHtml.Append("<br />");
        }

        public void Signature()
        {
            contentHtml.Append("<tr>");
            contentHtml.Append("<td>");
            Break();
            Break();
            Text("Um abraço,");
            Break();
            Text("Equipe Restou da Obra");
            contentHtml.Append("</td>");
            contentHtml.Append("</tr>");
        }


        private void Text(string text) {
            contentHtml.Append("<span style='font-family: Arial, sans - serif;'>");
            contentHtml.Append(text);
            contentHtml.Append("</span>");
        }

        public void AddLink(string name, string url)
        {
            contentHtml.Append("<tr>");
            contentHtml.Append("<td align='right'>");
            contentHtml.Append($"<a href='{url}' target='_blank' style='border:0;background-color:#ff0000;color:#ffffff;padding:5px 10px;text-decoration:none;border:0;' >{name}</a>");
            contentHtml.Append("</td>");
            contentHtml.Append("</tr>");
        }

    }
}
