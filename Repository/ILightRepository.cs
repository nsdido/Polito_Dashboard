using Climate_Watch.Models;

namespace Dashboard.Repository;

public interface ILightRepository {
    
    IEnumerable<LightDto> GetAll();
}