using System.Text.Json;
using Newtonsoft.Json;
using safeclimb_security.Security.HttpResource;

namespace safeclimb_security.Security.Connection;

public class ConnectionService
{
    private readonly HttpClient _httpClient;
    private const string BaseApiUrl = "https://localhost:44392/api/v1/";
    
    public ConnectionService()
    {
        _httpClient = new HttpClient();
    }
    public async Task<List<T>> GetAllResponse<T>(string name)
    {
        var response = await _httpClient.GetAsync(BaseApiUrl + name);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<List<T>>(responseContent);
            return customers;
        }
        else
        {
            throw new Exception($"Error al llamar al endpoint: {response.StatusCode}");
        }
    }
}