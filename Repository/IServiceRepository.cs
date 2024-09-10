using Dashboard.Models;

namespace Dashboard.Repository;

public interface IServiceRepository {
    IEnumerable<ServiceDto> GetAll();
}