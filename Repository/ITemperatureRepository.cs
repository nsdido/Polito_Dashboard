using Dashboard.Models;

namespace Dashboard.Repository;

public interface ITemperatureRepository {
    
    IEnumerable<TemperatureDto> GetAll();
}