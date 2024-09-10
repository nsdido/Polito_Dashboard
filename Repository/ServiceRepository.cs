using System.Net;
using Dashboard.Models;
using Dashboard.Repository;

namespace Dashboard.Repository;

public class ServiceRepository : IServiceRepository {
    public IEnumerable<ServiceDto> GetAll()
    {
        var url = "http://43.131.48.203:8083/catalog/services";


        using var client = new HttpClient();

        var response = client.GetAsync(url).Result;
        if (response.StatusCode is HttpStatusCode.NotFound or HttpStatusCode.BadRequest)
        {
            return new List<ServiceDto>();
        }

        response.EnsureSuccessStatusCode();
        var responseBody = response.Content.ReadAsStringAsync().Result;

        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceModel>(responseBody);

        return result.list.ToList();
    }
    
}