using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using WebClient.Models;

namespace MyApp.Namespace
{
    public class CallingAPIModel : PageModel
    {

        public List<IdentityDTO>? container {get;set;}

        public async Task<PageResult> OnGetAsync()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",accessToken); 
            var result = await client.GetAsync("https://localhost:7168/api/identity");
            if (result.IsSuccessStatusCode){
                container = await result.Content.ReadFromJsonAsync<List<IdentityDTO>>();
            }
            return Page();
        }
    }
}
