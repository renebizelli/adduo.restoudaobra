#pragma checksum "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/_Masterpage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74a6a67df96e43444f095a406cbd84a7d3e2e541"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Masterpage), @"mvc.1.0.view", @"/Views/Shared/_Masterpage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Masterpage.cshtml", typeof(AspNetCore.Views_Shared__Masterpage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74a6a67df96e43444f095a406cbd84a7d3e2e541", @"/Views/Shared/_Masterpage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cae6a556c7850657f0a0cdd9d675c0998b8da722", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Masterpage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 118, true);
            WriteLiteral("<!DOCTYPE html>\n<html xmlns=\"http://www.w3.org/1999/xhtml\" ng-app=\"ROApp\" ng-controller=\"mainController\" esc-trigger>\n");
            EndContext();
            BeginContext(118, 2353, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0625d7ff23a44f6b86ae754724851ea0", async() => {
                BeginContext(124, 21, true);
                WriteLiteral("\n    <title>\n        ");
                EndContext();
                BeginContext(146, 28, false);
#line 5 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/_Masterpage.cshtml"
   Write(RenderSection("title", true));

#line default
#line hidden
                EndContext();
                BeginContext(174, 683, true);
                WriteLiteral(@"
    </title>
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width"" />
    <meta http-equiv=""CACHE-CONTROL"" content=""NO-CACHE"">
    <meta http-equiv=""PRAGMA"" content=""NO-CACHE"">
    <meta name=""theme-color"" content=""#ffffff"">
    <link rel=""canonical"" href=""http://www.restoudaobra.com.br/"" />
    <link rel=""alternate"" hreflang=""pt-BR"" href=""http://www.restoudaobra.com.br/"" />
    <meta name=""keywords"" content=""resto, obra, construção, material, doação, venda, sobra, sustentabilidade, sociedade, social, "" />
    <meta name=""author"" content=""Restou da Obra"">
    <meta name=""copyright"" content=""Copyright © Restou da Obra. All Rights Reserved."">

    ");
                EndContext();
                BeginContext(858, 28, false);
#line 18 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/_Masterpage.cshtml"
Write(RenderSection("meta", false));

#line default
#line hidden
                EndContext();
                BeginContext(886, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(892, 33, false);
#line 19 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/_Masterpage.cshtml"
Write(RenderSection("richcards", false));

#line default
#line hidden
                EndContext();
                BeginContext(925, 384, true);
                WriteLiteral(@"

    <link rel=""shortcut icon"" href=""favicon.ico"" type=""image/x-icon"">
    <link rel=""icon"" href=""favicon.ico"" type=""image/x-icon"">
    <base href=""/"">

    <script src=""_script/lib/jquery/3.1.0/jquery-3.1.0.min.js""></script>
    <script src=""_script/lib/angular/1.5.8/angular.js?v=20180522""></script>
    <script src=""_script/lib/angular/1.5.8/angular-cookies.min.js""></script>
    ");
                EndContext();
                BeginContext(1310, 30, false);
#line 28 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/_Masterpage.cshtml"
Write(RenderSection("script", false));

#line default
#line hidden
                EndContext();
                BeginContext(1340, 1124, true);
                WriteLiteral(@"


    <link href=""_style/font.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/config.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/struct.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/style.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/header.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/footer.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/form.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/dropdown.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/search.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/ad.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/home.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/myad.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/how.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/purpose.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/identification.css?v=20180522"" rel=""stylesheet"" />
    <link href=""_style/contact.css?v");
                WriteLiteral("=20180522\" rel=\"stylesheet\" />\n    <link href=\"_style/payment.css?v=20180522\" rel=\"stylesheet\" />\n\n\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2471, 2, true);
            WriteLiteral("\n\n");
            EndContext();
            BeginContext(2474, 12, false);
#line 52 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/_Masterpage.cshtml"
Write(RenderBody());

#line default
#line hidden
            EndContext();
            BeginContext(2486, 11, true);
            WriteLiteral("\n\n</html>\n\n");
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
