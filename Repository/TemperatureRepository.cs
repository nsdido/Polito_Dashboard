using System.Net;
using Dashboard.Models;
using Dashboard.Repository;

namespace Dashboard.Repository;

public class TemperatureRepository : ITemperatureRepository {
    public IEnumerable<TemperatureDto> GetAll()
    {
        var url = "http://43.131.48.203:8083/data/temperature?page=1&size=100";


        using var client = new HttpClient();

        var response = client.GetAsync(url).Result;
        if (response.StatusCode is HttpStatusCode.NotFound or HttpStatusCode.BadRequest)
        {
            return new List<TemperatureDto>();
        }

        response.EnsureSuccessStatusCode();
        var responseBody = response.Content.ReadAsStringAsync().Result;

        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<MeasuredTemperatureModel>(responseBody);

        return result.List.ToList();
    }
}