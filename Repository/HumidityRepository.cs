using System.Net;
using Dashboard.Models;
using Dashboard.Repository;

namespace Dashboard.Repository;

public class HumidityRepository : IHumidityRepository {
    public IEnumerable<HumidityDto> GetAll()
    {
        var url = "http://43.131.48.203:8083/data/humidity?page=1&size=100";


        using var client = new HttpClient();

        var response = client.GetAsync(url).Result;
        if (response.StatusCode is HttpStatusCode.NotFound or HttpStatusCode.BadRequest)
        {
            return new List<HumidityDto>();
        }

        response.EnsureSuccessStatusCode();
        var responseBody = response.Content.ReadAsStringAsync().Result;

        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<HumidityModel>(responseBody);

        return result.List.ToList();
    }
}