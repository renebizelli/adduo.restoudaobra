#pragma checksum "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/SPA/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02a1b3abf1547698e5b33ed1520c7ece390ab768"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SPA_Index), @"mvc.1.0.view", @"/Views/SPA/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SPA/Index.cshtml", typeof(AspNetCore.Views_SPA_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02a1b3abf1547698e5b33ed1520c7ece390ab768", @"/Views/SPA/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cae6a556c7850657f0a0cdd9d675c0998b8da722", @"/Views/_ViewImports.cshtml")]
    public class Views_SPA_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "Menu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "Footer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "GoogleAnalytics", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/SPA/Index.cshtml"
  
    Layout = "~/Views/Shared/_Masterpage.cshtml";

#line default
#line hidden
            BeginContext(55, 2, true);
            WriteLiteral("\n\n");
            EndContext();
            DefineSection("title", async() => {
                BeginContext(77, 15, true);
                WriteLiteral("\n    {{title}}\n");
                EndContext();
            }
            );
            BeginContext(94, 1, true);
            WriteLiteral("\n");
            EndContext();
            DefineSection("meta", async() => {
                BeginContext(114, 44, true);
                WriteLiteral("\n    <meta name=\"robots\" content=\"noindex\">\n");
                EndContext();
            }
            );
            BeginContext(160, 1, true);
            WriteLiteral("\n");
            EndContext();
            DefineSection("script", async() => {
                BeginContext(178, 2374, true);
                WriteLiteral(@"

    <script src=""_script/lib/angular-ui/ngMask.js?v=20180522""></script>
    <script src=""_script/lib/angular-ui/ng-file-upload-all.min.js?v=20180522""></script>
    <script src=""_script/lib/angular/1.5.8/angular-route.min.js?v=20180522""></script>

    <script src=""_script/spa/module.js?v=20180522""></script>
    <script src=""_script/spa/factory.js?v=20180522""></script>
    <script src=""_script/spa/owner/authFactory.js?v=20180522""></script>
    <script src=""_script/spa/interceptor.js""></script>
    <script src=""_script/spa/config.js?v=20180522""></script>
    <script src=""_script/spa/directive.js?v=20180522""></script>
    <script src=""_script/common/directive.js""></script>
    <script src=""_script/spa/controller.js?v=20180522""></script>
    <script src=""_script/spa/home/homeController.js?v=20180522""></script>
    <script src=""_script/spa/basic/basicController.js?v=20180522""></script>
    <script src=""_script/spa/purpose/purposeController.js?v=20180522""></script>
    <script src=""_script/spa/how/howController.js");
                WriteLiteral(@"?v=20180522""></script>
    <script src=""_script/spa/ad/searchDirective.js?v=20180522""></script>
    <script src=""_script/spa/ad/searchFactory.js?v=20180522""></script>
    <script src=""_script/spa/ad/searchService.js?v=20180522""></script>
    <script src=""_script/spa/ad/searchController.js?v=20180522""></script>
    <script src=""_script/spa/ad/adController.js?v=20180522""></script>
    <script src=""_script/spa/ad/paymentController.js?v=20180522""></script>
    <script src=""_script/spa/ad/addressService.js?v=20180522""></script>
    <script src=""_script/spa/ad/productRegisterDirective.js?v=20180522""></script>
    <script src=""_script/spa/ad/productImageService.js?v=20180522""></script>
    <script src=""_script/spa/ad/adFactory.js?v=20180522""></script>
    <script src=""_script/spa/ad/adService.js?v=20180522""></script>
    <script src=""_script/spa/ad/myadController.js?v=20180522""></script>
    <script src=""_script/spa/owner/ownerFactory.js?v=20180522""></script>
    <script src=""_script/spa/owner/ownerService.js?v=2018");
                WriteLiteral(@"0522""></script>
    <script src=""_script/spa/owner/ownerController.js?v=20180522""></script>
    <script src=""_script/spa/contact/contactFactory.js?v=20180522""></script>
    <script src=""_script/spa/contact/contactService.js?v=20180522""></script>
    <script src=""_script/spa/contact/contactController.js?v=20180522""></script>
");
                EndContext();
            }
            );
            BeginContext(2554, 2, true);
            WriteLiteral("\n\n");
            EndContext();
            BeginContext(2556, 167, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c62f0f408d8452693f9aeb89b53d013", async() => {
                BeginContext(2562, 6, true);
                WriteLiteral("\n\n    ");
                EndContext();
                BeginContext(2568, 23, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "719eb5a705c14d549368858a84b215c4", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2591, 58, true);
                WriteLiteral("\n\n    <main>\n        <ng-view></ng-view>\n    </main>\n\n    ");
                EndContext();
                BeginContext(2649, 25, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "14e11ea8782c4e30900065675340f0f2", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2674, 6, true);
                WriteLiteral("\n\n    ");
                EndContext();
                BeginContext(2680, 34, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f007b97cf2194c579064e80bd7e67eac", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2714, 2, true);
                WriteLiteral("\n\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2723, 3, true);
            WriteLiteral("\n\n\n");
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
