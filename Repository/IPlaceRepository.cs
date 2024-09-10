using Dashboard.Models;

namespace Dashboard.Repository;

public interface IPlaceRepository {

    void CreatePlace(DefineHome place);
    void UpdatePlace(DefineHome place);

    IEnumerable<DefinedHome> GetPlaces(string telegramId);

    IEnumerable<string> GetUsersInPlace(long placeId);

    void AddUserToPlace(AddUserToPlace place);
}