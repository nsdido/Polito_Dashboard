using Dashboard.Models;

namespace Dashboard.Repository;

public interface IHistoricalDataRepository {

    IEnumerable<HistoricalData> GetHistoricalData(string sensorName, long placeId);
}