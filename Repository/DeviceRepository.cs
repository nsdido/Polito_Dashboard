using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Dashboard.Models;
using Dashboard.Repository;

namespace Dashboard.Repository;

public class DeviceRepository : IDeviceRepository {
    public IEnumerable<DeviceModel> GetAll()
    {
        var url = "http://43.131.48.203:8083/catalog/devices";


        using var client = new HttpClient();

        var response = client.GetAsync(url).Result;
        if (response.StatusCode is HttpStatusCode.NotFound or HttpStatusCode.BadRequest)
        {
            return new List<DeviceModel>();
        }

        response.EnsureSuccessStatusCode();
        var responseBody = response.Content.ReadAsStringAsync().Result;

        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DefinedDevice>(responseBody);

        return result.List.ToList();
    }

    public void Control(DeviceControl place)
    {
        try
        {
            string url = "http://43.131.48.203:8083/device/command/send";

            // Create an instance of HttpClient
            using HttpClient client = new HttpClient();
            // Serialize the data to JSON
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(place, options);

            // Create an HttpContent object
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Make the POST request
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            // Read the response content
            string responseString = response.Content.ReadAsStringAsync().Result;
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException("The create place api is not available");
        }
    }

    public void Create(DefinedEntity place)
    {
        throw new NotImplementedException();
    }

    public void Update(DefinedEntity place)
    {
        throw new NotImplementedException();
    }
}