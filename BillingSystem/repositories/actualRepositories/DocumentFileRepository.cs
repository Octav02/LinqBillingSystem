using BillingSystem.models;

namespace BillingSystem.repositories;

public class DocumentFileRepository : AbstractFileRepository<string, Document>
{
    public DocumentFileRepository(string fileName, CreateEntity<Document> createEntity) : base(fileName, createEntity)
    {
        loadFromFile();
    }
}