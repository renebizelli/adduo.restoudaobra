#pragma checksum "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "034a5233c03035f95273519e567f3e7488859ecd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_AdDetailInfo), @"mvc.1.0.view", @"/Views/Shared/AdDetailInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/AdDetailInfo.cshtml", typeof(AspNetCore.Views_Shared_AdDetailInfo))]
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
#line 3 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
using adduo.restoudaobra.web.helper;

#line default
#line hidden
#line 4 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
using adduo.restoudaobra.web.model;

#line default
#line hidden
#line 5 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
using adduo.restoudaobra.dto;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"034a5233c03035f95273519e567f3e7488859ecd", @"/Views/Shared/AdDetailInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cae6a556c7850657f0a0cdd9d675c0998b8da722", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_AdDetailInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CardDetailDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(21, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(125, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 7 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
  
    var card = Model;

    var type = AdTypeHelper.Get(card);

#line default
#line hidden
            BeginContext(193, 74, true);
            WriteLiteral("\n<div id=\"ad-detail-info\">\n\n    <div id=\"ad-detail-info-item\">\n        <h1");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 267, "\"", 290, 1);
#line 16 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 275, card.Ad.Name, 275, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(291, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(294, 12, false);
#line 16 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
                                Write(card.Ad.Name);

#line default
#line hidden
            EndContext();
            BeginContext(307, 17, true);
            WriteLiteral("</h1>\n        <h2");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 324, "\"", 349, 1);
#line 17 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 332, card.Ad.Option, 332, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(350, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(353, 14, false);
#line 17 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
                                  Write(card.Ad.Option);

#line default
#line hidden
            EndContext();
            BeginContext(368, 17, true);
            WriteLiteral("</h2>\n        <h2");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 385, "\"", 409, 1);
#line 18 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 393, card.Ad.Brand, 393, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(410, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(413, 13, false);
#line 18 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
                                 Write(card.Ad.Brand);

#line default
#line hidden
            EndContext();
            BeginContext(427, 17, true);
            WriteLiteral("</h2>\n        <h2");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 444, "\"", 471, 1);
#line 19 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 452, card.Ad.Quantity, 452, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(472, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(475, 16, false);
#line 19 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
                                    Write(card.Ad.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(492, 7, true);
            WriteLiteral("</h2>\n\n");
            EndContext();
#line 21 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
         if (type.isSale)
        {

#line default
#line hidden
            BeginContext(535, 39, true);
            WriteLiteral("            <h2 class=\"text-color-type\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 574, "\"", 612, 1);
#line 23 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 582, card.Ad.Price.ToString("C"), 582, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(613, 7, true);
            WriteLiteral("></h2>\n");
            EndContext();
#line 24 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
        }

#line default
#line hidden
            BeginContext(630, 73, true);
            WriteLiteral("    </div>\n    <ul id=\"ad-detail-info-owner\">\n        <li id=\"owner-name\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 703, "\"", 734, 1);
#line 27 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 711, card.Owner.FirstName, 711, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(735, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(738, 20, false);
#line 27 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
                                                        Write(card.Owner.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(759, 437, true);
            WriteLiteral(@"</li>
        <li id=""owner-email"" ng-show=""showContact"">
            <span ng-click=""showContact()"" ng-class=""{'contact-hide': !contactVisible}""></span>
        </li>
        <li id=""owner-phone"">
            <span ng-hide=""contactVisible"" ng-click=""showContact()"" class=""contact-hide""></span>
            <span ng-repeat=""phone in phones"" class=""phone-separator"" title=""{{phone)"">tel</span>
        </li>
        <li id=""owner-address""");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1196, "\"", 1274, 5);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 1204, card.Address.District, 1204, 24, false);

#line default
#line hidden
            WriteAttributeValue("", 1228, ",", 1228, 1, true);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue(" ", 1229, card.Address.City, 1230, 20, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1250, "-", 1251, 2, true);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue(" ", 1252, card.Address.State, 1253, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1275, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1278, 21, false);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
                                                                                                          Write(card.Address.District);

#line default
#line hidden
            EndContext();
            BeginContext(1300, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(1304, 17, false);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
                                                                                                                                    Write(card.Address.City);

#line default
#line hidden
            EndContext();
            BeginContext(1322, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1327, 18, false);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.web/Views/Shared/AdDetailInfo.cshtml"
                                                                                                                                                           Write(card.Address.State);

#line default
#line hidden
            EndContext();
            BeginContext(1346, 22, true);
            WriteLiteral("</li>\n    </ul>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CardDetailDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
