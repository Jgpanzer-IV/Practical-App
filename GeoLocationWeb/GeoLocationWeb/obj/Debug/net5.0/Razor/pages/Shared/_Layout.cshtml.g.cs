#pragma checksum "D:\Software_Development\PracticalApps\GeoLocationWeb\GeoLocationWeb\pages\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36cd8675c71d645e3276baa0f56adcb027cb074c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.pages_Shared__Layout), @"mvc.1.0.view", @"/pages/Shared/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36cd8675c71d645e3276baa0f56adcb027cb074c", @"/pages/Shared/_Layout.cshtml")]
    public class pages_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!Doctype html>\r\n\r\n\r\n<html lang=\"en\">\r\n\t\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36cd8675c71d645e3276baa0f56adcb027cb074c2767", async() => {
                WriteLiteral(@"

		<link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"" rel=""stylesheet"" 
			integrity=""sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"" 
			crossorigin=""anonymous"">

		<link rel=""stylesheet"" type=""text/css"" href=""/stylesheet/Style01.css"" />

		<title>");
#nullable restore
#line 14 "D:\Software_Development\PracticalApps\GeoLocationWeb\GeoLocationWeb\pages\Shared\_Layout.cshtml"
          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n\t\t\r\n\t\t\r\n\t\t\r\n\r\n\t");
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
            WriteLiteral("\r\n\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36cd8675c71d645e3276baa0f56adcb027cb074c4358", async() => {
                WriteLiteral(@"
		<header>

			<nav class=""navbar navbar-expand-md navbar-dark bg-dark"">
				<div class=""container justify-content-start"" >
					
					<a class=""navbar-brand"" href=""/"">Geolocation</a>

					<ul class=""navbar-nav"">
						<li class=""nav-item"">
							<a class=""nav-link"" href=""/AccessPosition/"">Access Position</a>
						</li>
						<li class=""nav-item"">
							<a class=""nav-link"" href=""/RecordPosition/"">Recording position</a>
						</li>

						<li class=""nav-item"">
							<a class=""nav-link"" href=""/GoogleMap/"" >Google Static Map API</a>
						</li>
						<li class=""nav-item"">
							<a class=""nav-link"" href=""/DynamicMap/"">Dynamic Map</a>
						</li>
						<li>
							<a class=""nav-link"" href=""/FindMyPosition"">Find my positison</a>
						</li>
						<li>
							<a class=""nav-link"" href=""/DistanceCalculator"">Distance Calculator</a>
						</li>
						<li>
							<a class=""nav-link"" href=""/MapDirection"">Map Direction</a>
						</li>
					</ul>

				</div>
			</nav>

		</header>
                WriteLiteral("\n\r\n\t\t<main>\r\n\t\t\t<div class=\"container\">\r\n\t\t\t\t");
#nullable restore
#line 61 "D:\Software_Development\PracticalApps\GeoLocationWeb\GeoLocationWeb\pages\Shared\_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
			</div>
		</main>

		<footer></footer>

		<script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"" 
			integrity=""sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM"" 
			crossorigin=""anonymous""></script>

		

		");
#nullable restore
#line 73 "D:\Software_Development\PracticalApps\GeoLocationWeb\GeoLocationWeb\pages\Shared\_Layout.cshtml"
   Write(RenderSection("Scripts",required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\t");
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
            WriteLiteral("\r\n\r\n\r\n\r\n</html>");
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