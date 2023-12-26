using BillingSystem.repositories;

namespace BillingSystem.utils.mappers;

public class DataReader
{
    public static List<T> ReadData<T>(string fileName, CreateEntity<T> createEntity)
    {
        var entities = new List<T>();
        using (var sr = new StreamReader(fileName))
        {
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                var entity = createEntity(line);
                entities.Add(entity);
            }
        }

        return entities;
    }
}