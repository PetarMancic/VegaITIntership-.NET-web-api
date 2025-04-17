using Bookstore.Domain.DTO;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Exceptions;
using Bookstore.MappingExtensions.AuthorMappingExtensions;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Commands;
public class UpdateAuthorCommandHandler :IRequestHandler<UpdateAuthorCommand, BaseOperationResultDTO>
{
    private readonly IGenericRepository<Author> _authorRepo;
    public UpdateAuthorCommandHandler( IGenericRepository<Author> authorRepo)
    {
        _authorRepo = authorRepo;
    }
    public async Task<BaseOperationResultDTO> Handle (UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
       
       var existingAuthor = await _authorRepo.GetByIdAsync(request.authorId);
        if (existingAuthor is null)
        {
            throw new  AuthorNotFoundExcpetion(request.authorId);
        }
        existingAuthor.ApplyUpdate(request.updateAuthorDto.newName, 
                                  request.updateAuthorDto.newSurname,
                                  request.updateAuthorDto.newCountry);
        await _authorRepo.UpdateAsync(existingAuthor);

        return new BaseOperationResultDTO(true, ConstantsApplication.AuthorExceptionMessages.AuthorUpdated);
    }
}

