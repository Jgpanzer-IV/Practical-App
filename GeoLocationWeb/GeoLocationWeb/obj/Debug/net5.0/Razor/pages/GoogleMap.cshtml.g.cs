#pragma checksum "D:\Software_Development\PracticalApps\GeoLocationWeb\GeoLocationWeb\pages\GoogleMap.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fe00ea6d8cf6d64985b1d2211e676d4a7b8c988"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.pages_GoogleMap), @"mvc.1.0.razor-page", @"/pages/GoogleMap.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fe00ea6d8cf6d64985b1d2211e676d4a7b8c988", @"/pages/GoogleMap.cshtml")]
    public class pages_GoogleMap : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 13 "D:\Software_Development\PracticalApps\GeoLocationWeb\GeoLocationWeb\pages\GoogleMap.cshtml"
  
	ViewData["Title"] = "Static Map API" + $"({typeMap})";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""jumbotron bg-dark text-light p-5 my-5 rounded text-center shadow"">

	<h1>Google Static Map API</h1>
	<p class=spanLarge>There are multiple type of static map.</p>

	<div class=""text-center mx-auto w-50 bg-danger"">

		<ul id=""selector"" class=""list-group w-100 bg-dark text-light d-block"">
			<li  class=""list-group-item list-group-item-action"">roadmap</li>
			<li  class=""list-group-item list-group-item-action"">satellite</li>
			<li  class=""list-group-item list-group-item-action"">HYBRID</li>
			<li  class=""list-group-item list-group-item-action"">TERRAIN</li>
		</ul>

	</div>
	<p class=""display-4"">Selected Map type</p>
	<h2 id=""mapSelected""></h2>

	<p> Click one of these type map to see the difference.</p>

</div>

<div class=""d-flex flex-wrap justify-content-center bg-dark rounded shadow-sm my-5"" >

	<!-- Getteing Postion (Latitude , Longitude) -->
	<div class=""shadow-sm rounded p-4 m-4 bg-light"" style=""width:600px; height:500px;"">
		<form href=""#"" method=""post"">
			<d");
            WriteLiteral(@"iv class=""form-group"">
				<label for=""laTbx"">Latitude : </label>
				<input type=""text"" class=""form-control"" name=""latitudeTbx"" id=""laTbx"" />
				<label for=""longTbx"">Longitude : </label>
				<input type=""text"" class=""form-control"" name=""longitudeTbx"" id=""longTbx""/>
			</div>
		</form>
		<button class=""btn btn-danger my-3"" id=""getMap"">Get map</button>
		<p class=""spanLarge"" id=""showPosi""></p>
	</div>
	

	<!-- Ouput Map -->

	<div class=""m-4 shadow-sm rounded bg-light"" style=""width:600px; height:500px;"">
		<div id=""staticMap"" class=""w-100 h-100 rounded""> </div>
	</div>


</div>

<!--
	URL Google static map API
		https://maps.googleapis.com/maps/api/staticmap? 

	Parameter 
		center=Brooklyn+Bridge,New+York,NY   : address or latitude,longitude
		&zoom=13   : value between 0 - 21
		&size=600x300 
		&maptype=roadmap
		&markers=color:blue%7Clabel:S%7C40.702147,-74.015794
		&markers=color:green%7Clabel:G%7C40.711614,-74.012318
		&markers=color:red%7Clabel:C%7C40.718217,-73.998284
	");
            WriteLiteral(@"	&key=YOUR_API_KEY 
-->

<script type=""text/javascript"">

	var selectedType;

	var elementSelector = document.getElementById('selector').getElementsByTagName('li');
	for (i=0; i< elementSelector.length; i++){
	
		elementSelector[i].onclick = selectType;
	}
	
	document.getElementById('getMap').onclick = () => {

		let latitude = document.getElementById('laTbx').value;
		let longitude= document.getElementById('longTbx').value;


		var position = latitude + ',' + longitude;

		let key = 'AIzaSyDiwBlGIQmnaVtDhVK8p-SBQ8-LyRMLU1c';
		
		document.getElementById('showPosi').innerHTML = position;

		var mapUrl = 'https://maps.googleapis.com/maps/api/staticmap?center='+position+'&zoom=18&size=600x500&maptype='+selectedType+'&key='+key;
		
		document.getElementById('staticMap').innerHTML = '<img src='+mapUrl+'>';
	}

	function selectType (event){
		selectedType = event.target.innerHTML;
		document.getElementById(""mapSelected"").innerHTML = selectedType; 
	}


</script>");
        }
        #pragma warning restore 1998
#nullable restore
#line 3 "D:\Software_Development\PracticalApps\GeoLocationWeb\GeoLocationWeb\pages\GoogleMap.cshtml"
           

	public string typeMap { get; private set; }

	public void OnGet(string type="RoadMap")
	{
		typeMap = type;
	}

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<pages_GoogleMap> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<pages_GoogleMap> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<pages_GoogleMap>)PageContext?.ViewData;
        public pages_GoogleMap Model => ViewData.Model;
    }
}
#pragma warning restore 1591
