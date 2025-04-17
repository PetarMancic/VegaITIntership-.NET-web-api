using Bookstore.Domain.DTO.Author;
using Bookstore.Domain.Entities;
using Bookstore.MappingExtensions.AuthorMappingExtensions;

using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Queries;
public class GetAllAuthorsQueryHandler :IRequestHandler<GetAllAuthorsQuery, IEnumerable<NewAuthorDTO>>
{
    private readonly IGenericRepository<Author> _authorRepo; 
    public GetAllAuthorsQueryHandler(IGenericRepository<Author> authorRepo)
    {
        _authorRepo=authorRepo;
    } 
    public async Task<IEnumerable<NewAuthorDTO>> Handle (GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors= await _authorRepo.GetAllAsync();
        return authors.Select(author=> author.ToNewAuthorDTO()).ToList();
    }
}