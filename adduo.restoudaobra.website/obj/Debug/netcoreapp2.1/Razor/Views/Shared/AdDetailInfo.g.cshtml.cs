#pragma checksum "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "596516e7d4ae47de91030f059c965d65fc680618"
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
#line 3 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
using adduo.restoudaobra.website.helper;

#line default
#line hidden
#line 4 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
using adduo.restoudaobra.website.model;

#line default
#line hidden
#line 5 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
using adduo.restoudaobra.dto;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"596516e7d4ae47de91030f059c965d65fc680618", @"/Views/Shared/AdDetailInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cae6a556c7850657f0a0cdd9d675c0998b8da722", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_AdDetailInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CardDetailDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(21, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(133, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 7 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
  
    var card = Model;

    var type = AdTypeHelper.Get(card);

#line default
#line hidden
            BeginContext(201, 74, true);
            WriteLiteral("\n<div id=\"ad-detail-info\">\n\n    <div id=\"ad-detail-info-item\">\n        <h1");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 275, "\"", 298, 1);
#line 16 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 283, card.Ad.Name, 283, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(299, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(302, 12, false);
#line 16 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
                                Write(card.Ad.Name);

#line default
#line hidden
            EndContext();
            BeginContext(315, 17, true);
            WriteLiteral("</h1>\n        <h2");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 332, "\"", 357, 1);
#line 17 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 340, card.Ad.Option, 340, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(358, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(361, 14, false);
#line 17 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
                                  Write(card.Ad.Option);

#line default
#line hidden
            EndContext();
            BeginContext(376, 17, true);
            WriteLiteral("</h2>\n        <h2");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 393, "\"", 417, 1);
#line 18 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 401, card.Ad.Brand, 401, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(418, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(421, 13, false);
#line 18 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
                                 Write(card.Ad.Brand);

#line default
#line hidden
            EndContext();
            BeginContext(435, 17, true);
            WriteLiteral("</h2>\n        <h2");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 452, "\"", 479, 1);
#line 19 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 460, card.Ad.Quantity, 460, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(480, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(483, 16, false);
#line 19 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
                                    Write(card.Ad.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(500, 7, true);
            WriteLiteral("</h2>\n\n");
            EndContext();
#line 21 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
         if (type.isSale)
        {

#line default
#line hidden
            BeginContext(543, 39, true);
            WriteLiteral("            <h2 class=\"text-color-type\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 582, "\"", 620, 1);
#line 23 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 590, card.Ad.Price.ToString("C"), 590, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(621, 7, true);
            WriteLiteral("></h2>\n");
            EndContext();
#line 24 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
        }

#line default
#line hidden
            BeginContext(638, 73, true);
            WriteLiteral("    </div>\n    <ul id=\"ad-detail-info-owner\">\n        <li id=\"owner-name\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 711, "\"", 742, 1);
#line 27 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 719, card.Owner.FirstName, 719, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(743, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(746, 20, false);
#line 27 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
                                                        Write(card.Owner.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(767, 437, true);
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
            BeginWriteAttribute("title", " title=\"", 1204, "\"", 1282, 5);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue("", 1212, card.Address.District, 1212, 24, false);

#line default
#line hidden
            WriteAttributeValue("", 1236, ",", 1236, 1, true);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue(" ", 1237, card.Address.City, 1238, 20, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1258, "-", 1259, 2, true);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
WriteAttributeValue(" ", 1260, card.Address.State, 1261, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1283, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1286, 21, false);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
                                                                                                          Write(card.Address.District);

#line default
#line hidden
            EndContext();
            BeginContext(1308, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(1312, 17, false);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
                                                                                                                                    Write(card.Address.City);

#line default
#line hidden
            EndContext();
            BeginContext(1330, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1335, 18, false);
#line 35 "/Users/rene/Desktop/GIT/adduo.restoudaobra/adduo.restoudaobra.website/Views/Shared/AdDetailInfo.cshtml"
                                                                                                                                                           Write(card.Address.State);

#line default
#line hidden
            EndContext();
            BeginContext(1354, 22, true);
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
