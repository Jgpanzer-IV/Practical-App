#pragma checksum "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "942e1961cb1e4dafdb8721810ec44d67c869a055"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerByID), @"mvc.1.0.view", @"/Views/Customer/CustomerByID.cshtml")]
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
#line 1 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\_ViewImports.cshtml"
using Consuming_Service;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\_ViewImports.cshtml"
using Consuming_Service.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"942e1961cb1e4dafdb8721810ec44d67c869a055", @"/Views/Customer/CustomerByID.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4d106256d6006734507e0317a54589db30c511d", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerByID : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Suntrack.Shared.Customer>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
  
    string errorMessage = ViewData["errorID"] as string;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"jumbotron\">\r\n\r\n");
#nullable restore
#line 9 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
     if (Model != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"display-3\">");
#nullable restore
#line 11 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                        Write(Model.ContactName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p style=\"font-size: 24px;\" class=\"lead\">");
#nullable restore
#line 12 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                                            Write(Model.ContactTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <hr />\r\n        <p style=\"font-size: 20px;\">Company : ");
#nullable restore
#line 14 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                                         Write(Model.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p style=\"font-size: 20px;\">Address : ");
#nullable restore
#line 15 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                                         Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p style=\"font-size: 20px;\">City : ");
#nullable restore
#line 16 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                                      Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p style=\"font-size: 20px;\">Postal code : ");
#nullable restore
#line 17 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                                             Write(Model.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p style=\"font-size: 20px;\">Fex : ");
#nullable restore
#line 18 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                                     Write(Model.Fax);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p style=\"font-size: 20px;\">Phone : ");
#nullable restore
#line 19 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                                       Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>      ");
#nullable restore
#line 19 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                                                                  }
    else {
        if (errorMessage == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1 class=\"text-danger lead\">Please Specify customer ID to search</h1>\r\n");
#nullable restore
#line 24 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
        }
        else { 

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1 class=\"text-danger lead\"> There is no User id : ");
#nullable restore
#line 26 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
                                                           Write(ViewData["errorID"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            <p class=\"lead text-info\">Please try another user ID.</p>\r\n");
#nullable restore
#line 28 "W:\Software_Development\PracticalApps\Consuming Northwind_Service\Consuming Northwind_Service\Views\Customer\CustomerByID.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Suntrack.Shared.Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
