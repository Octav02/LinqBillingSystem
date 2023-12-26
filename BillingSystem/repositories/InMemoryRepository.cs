using BillingSystem.models;

namespace BillingSystem.repositories;

public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
{
    protected IDictionary<ID, E> _entities = new Dictionary<ID, E>();

    public IEnumerable<E> FindAll()
    {
        return _entities.Values.ToList();
    }
}