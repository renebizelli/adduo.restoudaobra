#pragma checksum "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65f80750dc2c4144742cdc17669ab8ebd5025a6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_HomeCard), @"mvc.1.0.view", @"/Views/Shared/HomeCard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/HomeCard.cshtml", typeof(AspNetCore.Views_Shared_HomeCard))]
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
#line 2 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
using adduo.restoudaobra.dto;

#line default
#line hidden
#line 3 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
using adduo.restoudaobra.web.helper;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65f80750dc2c4144742cdc17669ab8ebd5025a6b", @"/Views/Shared/HomeCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cae6a556c7850657f0a0cdd9d675c0998b8da722", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_HomeCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CardSearchDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
  
    var helper = AdTypeHelper.Get(Model);


#line default
#line hidden
            BeginContext(144, 4, true);
            WriteLiteral("\r\n<a");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 148, "\"", 196, 2);
            WriteAttributeValue("", 156, "item", 156, 4, true);
#line 9 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
WriteAttributeValue(" ", 160, helper.Type.ToString().ToLower(), 161, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 197, "\"", 247, 6);
            WriteAttributeValue("", 204, "/", 204, 1, true);
#line 9 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
WriteAttributeValue("", 205, helper.URL, 205, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 218, "/", 218, 1, true);
#line 9 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
WriteAttributeValue("", 219, Model.Ad.URL, 219, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 232, "/", 232, 1, true);
#line 9 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
WriteAttributeValue("", 233, Model.Ad.Guid, 233, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 248, "\"", 270, 1);
#line 9 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
WriteAttributeValue("", 256, Model.Ad.Name, 256, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(271, 30, true);
            WriteLiteral(">\r\n    <div class=\"item-thumb\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 301, "\"", 343, 3);
            WriteAttributeValue("", 309, "background-image:url(", 309, 21, true);
#line 10 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
WriteAttributeValue("", 330, Model.Image, 330, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 342, ")", 342, 1, true);
            EndWriteAttribute();
            BeginContext(344, 16, true);
            WriteLiteral("></div>\r\n    <i>");
            EndContext();
            BeginContext(362, 11, false);
#line 11 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
   Write(helper.Name);

#line default
#line hidden
            EndContext();
            BeginContext(374, 32, true);
            WriteLiteral("</i>\r\n    <h2 class=\"item-name\">");
            EndContext();
            BeginContext(407, 13, false);
#line 12 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
                     Write(Model.Ad.Name);

#line default
#line hidden
            EndContext();
            BeginContext(420, 15, true);
            WriteLiteral("</h2>\r\n    <h2>");
            EndContext();
            BeginContext(436, 14, false);
#line 13 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
   Write(Model.Ad.Brand);

#line default
#line hidden
            EndContext();
            BeginContext(450, 15, true);
            WriteLiteral("</h2>\r\n    <h2>");
            EndContext();
            BeginContext(466, 15, false);
#line 14 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
   Write(Model.Ad.Option);

#line default
#line hidden
            EndContext();
            BeginContext(481, 23, true);
            WriteLiteral("</h2>\r\n    <span>Estou ");
            EndContext();
            BeginContext(506, 11, false);
#line 15 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/HomeCard.cshtml"
            Write(helper.Name);

#line default
#line hidden
            EndContext();
            BeginContext(518, 15, true);
            WriteLiteral("</span>\r\n</a>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CardSearchDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
