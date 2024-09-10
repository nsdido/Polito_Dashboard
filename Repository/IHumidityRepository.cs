using Dashboard.Models;

namespace Dashboard.Repository;

public interface IHumidityRepository {
    
    IEnumerable<HumidityDto> GetAll();
}