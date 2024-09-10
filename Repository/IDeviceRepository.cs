using Dashboard.Models;

namespace Dashboard.Repository;

public interface IDeviceRepository {

    void Create(DefinedEntity place);
    void Update(DefinedEntity place);
    
    void Control(DeviceControl place);

    IEnumerable<DeviceModel> GetAll();
    
    
}