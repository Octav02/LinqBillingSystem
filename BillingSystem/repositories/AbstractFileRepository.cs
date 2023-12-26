using BillingSystem.models;
using BillingSystem.utils.mappers;

namespace BillingSystem.repositories;

public delegate E CreateEntity<E>(string line);

public abstract class AbstractFileRepository<ID, E> : InMemoryRepository<ID, E> where E : Entity<ID>
{
    protected CreateEntity<E> _createEntity;
    protected string _fileName;

    public AbstractFileRepository(string fileName, CreateEntity<E> createEntity)
    {
        _fileName = fileName;
        _createEntity = createEntity;
        if (_createEntity != null)
            loadFromFile();
    }

    protected void loadFromFile()
    {
        var entities = DataReader.ReadData(_fileName, _createEntity);
        entities.ForEach(entity => _entities[entity.Id] = entity);
    }
}