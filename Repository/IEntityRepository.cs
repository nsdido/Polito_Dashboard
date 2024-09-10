using Dashboard.Models;

namespace Dashboard.Repository;

public interface IEntityRepository {

    void CreateEntity(DefinedEntity place);
    void UpdateEntity(DefinedEntity place);

    IEnumerable<DefinedEntity> GetEntities();
}