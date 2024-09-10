using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Dashboard.Models;

namespace Dashboard.Repository;

public class RuleRepository : IRuleRepository {
    public IEnumerable<RuleModel> GetAll(int page, int size)
    {
        var url = "http://43.131.48.203:8083/rules?page=1&size=100";


        using var client = new HttpClient();

        var response = client.GetAsync(url).Result;
        if (response.StatusCode is HttpStatusCode.NotFound or HttpStatusCode.BadRequest)
        {
            return new List<RuleModel>();
        }

        response.EnsureSuccessStatusCode();
        var responseBody = response.Content.ReadAsStringAsync().Result;

        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DefinedRule>(responseBody);

        return result.List.ToList();
    }


    public void Create(RuleModel place)
    {
        try
        {
            string url = "http://43.131.48.203:8083/rules";

            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
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
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException("The create place api is not available");
        }
    }

    public void Update(RuleModel place)
    {
        const string url = "http://43.131.48.203:8083/rules";

        // Create an instance of HttpClient
        using HttpClient client = new HttpClient();
        // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GenerateToken());


        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(place, options);


        // Create an HttpContent object
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Make the POST request
        var response = client.PutAsync(url, content).Result;

        // Read the response content
        var responseString = response.Content.ReadAsStringAsync().Result;

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new BadHttpRequestException("The create place api is not available");
        }
    }
}