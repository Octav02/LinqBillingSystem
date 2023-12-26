using BillingSystem.dtos;
using BillingSystem.repositories;
using Document = BillingSystem.models.Document;

namespace BillingSystem.services;

public class DocumentService
{
    private readonly IRepository<string, Document> _documentRepository;

    public DocumentService(IRepository<string, Document> documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public List<Document> GetAllDocuments()
    {
        return _documentRepository.FindAll().ToList();
    }

    public List<DocumentEmmisionDateDTO> getDocumentIssuedInYear(int year)
    {
        return _documentRepository.FindAll().Where(document => document.emmisionDate.Year == year)
            .Select(document => new DocumentEmmisionDateDTO
            {
                name = document.name,
                emmisionDate = document.emmisionDate
            }).ToList();
    }
}