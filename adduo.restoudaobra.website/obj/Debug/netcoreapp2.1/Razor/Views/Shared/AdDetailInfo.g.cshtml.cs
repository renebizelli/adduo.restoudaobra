#pragma checksum "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "917774e8822d89f4b694a2bfc97261eea15b849a"
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
#line 3 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
using adduo.restoudaobra.website.helper;

#line default
#line hidden
#line 4 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
using adduo.restoudaobra.website.model;

#line default
#line hidden
#line 5 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
using adduo.restoudaobra.dto;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"917774e8822d89f4b694a2bfc97261eea15b849a", @"/Views/Shared/AdDetailInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0016b6767730c936e45b5440b0aea7bd14cb65d3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_AdDetailInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CardDetailDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(138, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
  
    var card = Model;

    var type = AdTypeHelper.Get(card);

#line default
#line hidden
            BeginContext(212, 78, true);
            WriteLiteral("\r\n<div id=\"ad-detail-info\">\r\n\r\n    <div id=\"ad-detail-info-item\">\r\n        <h1");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 290, "\"", 313, 1);
#line 16 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
WriteAttributeValue("", 298, card.Ad.Name, 298, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(314, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(317, 12, false);
#line 16 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
                                Write(card.Ad.Name);

#line default
#line hidden
            EndContext();
            BeginContext(330, 18, true);
            WriteLiteral("</h1>\r\n        <h2");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 348, "\"", 373, 1);
#line 17 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
WriteAttributeValue("", 356, card.Ad.Option, 356, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(374, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(377, 14, false);
#line 17 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
                                  Write(card.Ad.Option);

#line default
#line hidden
            EndContext();
            BeginContext(392, 18, true);
            WriteLiteral("</h2>\r\n        <h2");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 410, "\"", 434, 1);
#line 18 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
WriteAttributeValue("", 418, card.Ad.Brand, 418, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(435, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(438, 13, false);
#line 18 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
                                 Write(card.Ad.Brand);

#line default
#line hidden
            EndContext();
            BeginContext(452, 18, true);
            WriteLiteral("</h2>\r\n        <h2");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 470, "\"", 497, 1);
#line 19 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
WriteAttributeValue("", 478, card.Ad.Quantity, 478, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(498, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(501, 16, false);
#line 19 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
                                    Write(card.Ad.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(518, 9, true);
            WriteLiteral("</h2>\r\n\r\n");
            EndContext();
#line 21 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
         if (type.isSale)
        {

#line default
#line hidden
            BeginContext(565, 39, true);
            WriteLiteral("            <h2 class=\"text-color-type\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 604, "\"", 642, 1);
#line 23 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
WriteAttributeValue("", 612, card.Ad.Price.ToString("C"), 612, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(643, 8, true);
            WriteLiteral("></h2>\r\n");
            EndContext();
#line 24 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
        }

#line default
#line hidden
            BeginContext(662, 75, true);
            WriteLiteral("    </div>\r\n    <ul id=\"ad-detail-info-owner\">\r\n        <li id=\"owner-name\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 737, "\"", 768, 1);
#line 27 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
WriteAttributeValue("", 745, card.Owner.FirstName, 745, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(769, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(772, 20, false);
#line 27 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
                                                        Write(card.Owner.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(793, 445, true);
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
            BeginWriteAttribute("title", " title=\"", 1238, "\"", 1316, 5);
#line 35 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
WriteAttributeValue("", 1246, card.Address.District, 1246, 24, false);

#line default
#line hidden
            WriteAttributeValue("", 1270, ",", 1270, 1, true);
#line 35 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
WriteAttributeValue(" ", 1271, card.Address.City, 1272, 20, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1292, "-", 1293, 2, true);
#line 35 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
WriteAttributeValue(" ", 1294, card.Address.State, 1295, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1317, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1320, 21, false);
#line 35 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
                                                                                                          Write(card.Address.District);

#line default
#line hidden
            EndContext();
            BeginContext(1342, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(1346, 17, false);
#line 35 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
                                                                                                                                    Write(card.Address.City);

#line default
#line hidden
            EndContext();
            BeginContext(1364, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1369, 18, false);
#line 35 "C:\inetpub\wwwroot\adduo.restoudaobra\adduo.restoudaobra.website\Views\Shared\AdDetailInfo.cshtml"
                                                                                                                                                           Write(card.Address.State);

#line default
#line hidden
            EndContext();
            BeginContext(1388, 24, true);
            WriteLiteral("</li>\r\n    </ul>\r\n</div>");
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
