using Climate_Watch.Models;

namespace Dashboard.Repository;

public interface IHumidityRepository {
    
    IEnumerable<HumidityDto> GetAll();
}