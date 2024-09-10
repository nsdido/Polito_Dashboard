using Climate_Watch.Models;

namespace Dashboard.Repository;

public interface IRuleRepository {
    IEnumerable<RuleModel> GetAll(int page, int size);
    
    void Create(RuleModel place);
    void Update(RuleModel place);

}