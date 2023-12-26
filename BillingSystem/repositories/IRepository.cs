using BillingSystem.models;

namespace BillingSystem.repositories;

public interface IRepository<ID, E> where E : Entity<ID>
{
    public IEnumerable<E> FindAll();
}