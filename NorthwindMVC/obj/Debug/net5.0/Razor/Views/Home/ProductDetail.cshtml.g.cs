#pragma checksum "W:\Software_Development\PracticalApps\NorthwindMVC\Views\Home\ProductDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05beda8c00abc749fdbab593c07f799391580103"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProductDetail), @"mvc.1.0.view", @"/Views/Home/ProductDetail.cshtml")]
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
#line 1 "W:\Software_Development\PracticalApps\NorthwindMVC\Views\_ViewImports.cshtml"
using NorthwindMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "W:\Software_Development\PracticalApps\NorthwindMVC\Views\_ViewImports.cshtml"
using NorthwindMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05beda8c00abc749fdbab593c07f799391580103", @"/Views/Home/ProductDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"070ee759cc6998b14c1fa7277a360b9582997943", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProductDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NorthwindMVC.Models.HomeProductDetailVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "W:\Software_Development\PracticalApps\NorthwindMVC\Views\Home\ProductDetail.cshtml"
  

   ViewData["Title"] = "Product Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"jumbotron shadow\">\r\n    <div class=\"text-left display-4\">");
#nullable restore
#line 8 "W:\Software_Development\PracticalApps\NorthwindMVC\Views\Home\ProductDetail.cshtml"
                                Write(Model.product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <hr>\r\n    <div class=\"text-left lead\">");
#nullable restore
#line 10 "W:\Software_Development\PracticalApps\NorthwindMVC\Views\Home\ProductDetail.cshtml"
                            Write(Model.product.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("$</div>\r\n    <div class=\"text-left\"> Quantity per Unit : ");
#nullable restore
#line 11 "W:\Software_Development\PracticalApps\NorthwindMVC\Views\Home\ProductDetail.cshtml"
                                           Write(Model.product.QuantityPerUnit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <div class=\"text-left\"> In Stock : ");
#nullable restore
#line 12 "W:\Software_Development\PracticalApps\NorthwindMVC\Views\Home\ProductDetail.cshtml"
                                  Write(Model.product.UnitsInStock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <div class=\"text-left\"> Category : ");
#nullable restore
#line 13 "W:\Software_Development\PracticalApps\NorthwindMVC\Views\Home\ProductDetail.cshtml"
                                  Write(Model.category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NorthwindMVC.Models.HomeProductDetailVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
