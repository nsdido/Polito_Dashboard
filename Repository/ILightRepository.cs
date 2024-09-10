using Dashboard.Models;

namespace Dashboard.Repository;

public interface ILightRepository {
    
    IEnumerable<LightDto> GetAll();
}