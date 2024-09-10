using Climate_Watch.Models;

namespace Dashboard.Repository;

public interface ITemperatureRepository {
    
    IEnumerable<TemperatureDto> GetAll();
}