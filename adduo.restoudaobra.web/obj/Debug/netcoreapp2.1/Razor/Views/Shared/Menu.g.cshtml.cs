#pragma checksum "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/Menu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ba173a8742bbd6fd71f111b4d1de175640a4f2a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Menu), @"mvc.1.0.view", @"/Views/Shared/Menu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Menu.cshtml", typeof(AspNetCore.Views_Shared_Menu))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ba173a8742bbd6fd71f111b4d1de175640a4f2a", @"/Views/Shared/Menu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cae6a556c7850657f0a0cdd9d675c0998b8da722", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Menu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 954, true);
            WriteLiteral(@"<header id=""menu-principal"">

    <div>
        <a href=""/"" id=""header-logo"" scroll-action title=""Pagina inicial - Restou da Obra""></a>
        <div id=""area-nav"">
            <nav>
                <a ng-show=""authenticated"" title=""Olá {{name}}"" id=""owner-name"">Olá {{name}} :)</a>
                <a href=""/quero-doar"" title=""Quero doar"">QUERO DOAR</a>
                <a href=""/quero-vender"" title=""Quero vender"">QUERO VENDER</a>
                <a href=""/meus-anuncios"" title=""Meus anúncios"" ng-show=""authenticated"">MEUS ANÚNCIOS</a>
                <a href=""/contato"" title=""Contato"">CONTATO</a>
                <a href=""/meus-dados"" ng-show=""authenticated"" title=""Meus dados"">MEUS DADOS</a>
                <a ng-show=""authenticated"" ng-click=""logout()"" title=""Sair"" class=""last"">SAIR</a>
                <a href=""/identificacao"" ng-hide=""authenticated"" title=""Entrar"" class=""last"">ENTRAR</a>
            </nav>
        </div>

    </div>

</header>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
