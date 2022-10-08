using IdentityModel.Client;
using Newtonsoft.Json;

// Discovery the ducument endpoint from metadata
var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
if (disco.IsError)
{
    Console.WriteLine("Error Discovery identity : " + disco.Error);
    return;
}

// Request an access token from identity server, This is done by the following rule
//      - The client-id must match to the defined client in the identity server.
//      - The Client-secret must correspond to the secret in the requested client-id
var tokenResult = await client.RequestClientCredentialsTokenAsync(
    new ClientCredentialsTokenRequest
    {
        Address = disco.TokenEndpoint,
        ClientId = "general", // Set Client id match to one of the defined client in identity-server
        ClientSecret = "secretVan2001", // Set Client secret 
        Scope = "identity retrieve" // Required scope
    }
);

if(tokenResult.IsError){
    Console.WriteLine("Error request to identity : " + tokenResult.Error);
    return;
}

// Print the access token
Console.WriteLine("Access token : "+tokenResult.AccessToken);


// Retrieve identity from api 

// Create client
var apiClient = new HttpClient();
// Set base address
apiClient.BaseAddress = new Uri("https://localhost:7168/");
apiClient.SetBearerToken(tokenResult.AccessToken);
HttpResponseMessage response = await apiClient.GetAsync("api/identity");
string message = string.Empty;
if(response.IsSuccessStatusCode){
    message = await response.Content.ReadAsStringAsync();
    
}else{
    message = "error status code : "+ response.StatusCode.ToString();
}

Console.WriteLine(message);
