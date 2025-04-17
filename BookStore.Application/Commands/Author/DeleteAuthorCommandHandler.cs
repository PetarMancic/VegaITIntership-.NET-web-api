using System.Reflection.Metadata;
using Bookstore.Domain.DTO;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Exceptions;
using BookStore.Domain.Interfaces;
using MediatR;
using Microsoft.VisualBasic;

namespace BookStore.Application.Commands;
public class DeleteAuthorCommandHandler :IRequestHandler<DeleteAuthorCommand,BaseOperationResultDTO>
{
    private readonly IGenericRepository<Author> _authorRepo;

    public DeleteAuthorCommandHandler(IGenericRepository<Author> authorRepo)
    {
        _authorRepo = authorRepo;
    }
    public async Task<BaseOperationResultDTO> Handle (DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var existingAuthor= await _authorRepo.GetByIdAsync(request.authorId);

        if ( existingAuthor is null)
        {
            throw new AuthorNotFoundExcpetion(request.authorId);
        }

        if (request.hardDelete)
        {
        if (await _authorRepo.DeleteAsync(existingAuthor, request.hardDelete) is 0) 
        {
            throw new  AuthorNotFoundExcpetion(request.authorId);
        }
        return new BaseOperationResultDTO(true, ConstantsApplication.AuthorExceptionMessages.AuthorHardDeleted);      
        }

    
        existingAuthor.IsDeleted=true;
        var booksToDelete= await _authorRepo.GetAllBooksForAuthor(request.authorId); 
        if( booksToDelete is not null)
        {
            foreach( var b in booksToDelete)
            {
                b.IsDeleted=true;
            }
        }
        if (await _authorRepo.UpdateAsync(existingAuthor) is null)
        {
            throw new  AuthorNotFoundExcpetion(request.authorId);
        }
        return new BaseOperationResultDTO(true, ConstantsApplication.AuthorExceptionMessages.AuthorSoftDeleted);
    }
}
