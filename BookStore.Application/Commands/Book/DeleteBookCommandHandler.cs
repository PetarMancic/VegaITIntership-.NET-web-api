using Bookstore.Domain.DTO;
using Bookstore.Domain.Exceptions;

using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Commands.Books;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BaseOperationResultDTO>
{
   
    private readonly IGenericRepository<Book> _bookRepo;
    public DeleteBookCommandHandler(IGenericRepository<Book> bookRepo)
    {
        _bookRepo = bookRepo;
    }
    public async Task<BaseOperationResultDTO> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
       var existingBook= await _bookRepo.GetByIdAsync(request.bookId);
        if (existingBook is null)
        {
            throw new BookNotFoundException(request.bookId);
        }

        if (request.hardDelete)
        {
            if (await _bookRepo.DeleteAsync(existingBook, request.hardDelete) is 0)
            {
                throw new BookNotFoundException(request.bookId);
            }
        return new BaseOperationResultDTO(true,ConstantsApplication.BookExceptionMessages.BookHardDeleted);        
        }

        existingBook.IsDeleted=true;
        if( await _bookRepo.UpdateAsync(existingBook) is null)
        {
             throw new BookNotFoundException(request.bookId);
        }
        return new BaseOperationResultDTO(true,ConstantsApplication.BookExceptionMessages.BookSoftDeleted);

    }
}
