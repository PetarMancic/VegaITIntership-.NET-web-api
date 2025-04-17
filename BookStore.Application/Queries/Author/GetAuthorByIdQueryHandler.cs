using Bookstore.Domain.DTO.AuthorDtos;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Exceptions;
using Bookstore.MappingExtensions.AuthorMappingExtensions;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Queries;
public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorDTO?>
{
    private readonly IGenericRepository<Author> _authorRepo;
    public GetAuthorByIdQueryHandler(IGenericRepository<Author> authorRepo )
    {
         _authorRepo=authorRepo;
    } 
    public async Task<GetAuthorDTO?> Handle (GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorRepo.GetByIdWithIncludesAsync(request.authorId, author => author.Books);
        if ( author is null)
        {
            throw new AuthorNotFoundExcpetion(request.authorId);
        }
        return author.ToGetAuthorDTO();   
    }
}

