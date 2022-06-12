#pragma checksum "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f9bb31da3919850836ef82e12e2911dc1f93cbf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\_ViewImports.cshtml"
using ChannelEngine_Sheldon;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\_ViewImports.cshtml"
using ChannelEngine_Sheldon.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9bb31da3919850836ef82e12e2911dc1f93cbf", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96a78b0045b6a7e820d2887c11ff6fb5c317cfce", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ChannelEngine_Sheldon.BusinessLogic.Models.HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
   Layout = "_Layout"; ViewBag.Title = "Top 5 Products Sold";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Top 5 Products Sold</h2>

<table class=""table table-sm table-striped table-bordered m-2"">
    <thead>
        <tr>
            <th>ProductName</th>
            <th>GTIN</th>
            <th>Quantity</th>
            <th>Set Stock Level</th>
            <th>Update Stock Level</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 17 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
         foreach (var o in Model.groupedProducts)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n            <td>");
#nullable restore
#line 21 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
           Write(o.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
           Write(o.Gtin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 23 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
           Write(o.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><input type =\"number\" name =\"StockLevel\" min=\"1\" max=\"1000\" step=\"1\"");
            BeginWriteAttribute("id", " id=\"", 731, "\"", 756, 1);
#nullable restore
#line 24 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
WriteAttributeValue("", 736, o.MerchantProductNo, 736, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100px\"/></td>\r\n            <td>\r\n                <input type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 834, "\"", 961, 9);
            WriteAttributeValue("", 844, "postStockLevel(\'", 844, 16, true);
#nullable restore
#line 26 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
WriteAttributeValue("", 860, o.MerchantProductNo.ToString(), 860, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 891, "\',", 891, 2, true);
            WriteAttributeValue(" ", 893, "\'", 894, 2, true);
#nullable restore
#line 26 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
WriteAttributeValue("", 895, o.StockLocationId.ToString(), 895, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 924, "\',", 924, 2, true);
            WriteAttributeValue(" ", 926, "\'", 927, 2, true);
#nullable restore
#line 26 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
WriteAttributeValue("", 928, o.MerchantProductNo.ToString(), 928, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 959, "\')", 959, 2, true);
            EndWriteAttribute();
            WriteLiteral(" value=\"Update Stock\" /> \r\n");
            WriteLiteral("            </td>\r\n        </tr>\r\n");
#nullable restore
#line 32 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<script type=\"text/javascript\">\r\n    var postStockLevel = function (merchantProductNo,stockLocationId, stockLevel) {\r\n        var sl = document.getElementById(stockLevel).value;\r\n\r\n        window.location.href = \'");
#nullable restore
#line 40 "C:\ChannelEngineAssessment\ChannelEngine_Sheldon\Views\Home\Index.cshtml"
                           Write(Url.Action("UpdateStock", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'?MerchantProductNo=\' + merchantProductNo + \'&StockLocationId=\' + stockLocationId + \'&StockLevel=\' + sl ;\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChannelEngine_Sheldon.BusinessLogic.Models.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
