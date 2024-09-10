using Climate_Watch.Models;

namespace Dashboard.Repository;

public interface IServiceRepository {
    IEnumerable<ServiceDto> GetAll();
}