using Bookstore.Domain.DTO.Author;
using Bookstore.Domain.Entities;
using Bookstore.MappingExtensions.AuthorMappingExtensions;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Commands;
public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, NewAuthorDTO>
{
    
    private readonly IGenericRepository<Author> _authorRepo;

    public CreateAuthorCommandHandler( IGenericRepository<Author> authorRepo)
    {
        
        _authorRepo= authorRepo;
    }
    public async Task<NewAuthorDTO> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var newAuthor = request.author.ToDomainEntity();
        await _authorRepo.AddAsync(newAuthor);
        return newAuthor.ToNewAuthorDTO();
    }
        

}
