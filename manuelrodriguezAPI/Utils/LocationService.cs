using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControllerLayer.Utils {
    public class LocationService {
        private readonly HttpClient _httpClient;

        public LocationService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<string> GetLocationAsync(string ipAddress) {
            try {
                var response = await _httpClient.GetStringAsync($"http://ip-api.com/json/{ipAddress}");

                var locationResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (locationResponse.TryGetValue("status", out var status) && status.ToString() == "success") {
                    var country = locationResponse["countryCode"].ToString();
                    return country ?? "";
                }

                return "";

            } catch (Exception ex) {
                return "";
            }      
        }
    }

}
