using Bookstore.Domain.DTO;
using Bookstore.Domain.Exceptions;
using Bookstore.MappingExtensions.BookMapingExtension;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Commands.Books;
public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BaseOperationResultDTO>
{
    private readonly IGenericRepository<Book> _bookRepo;
    public UpdateBookCommandHandler(IGenericRepository<Book> bookRepo)
    {
       _bookRepo=bookRepo;
    }
    public async Task<BaseOperationResultDTO> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
       var existingBook = await _bookRepo.GetByIdAsync(request.bookId);
        if (existingBook is null)
        {
            throw new BookNotFoundException(request.bookId);
        }
        
        existingBook.ToUpdateBookDTO(request.updateBookDto.Title);
        await _bookRepo.UpdateAsync(existingBook);
        return new BaseOperationResultDTO(true, ConstantsApplication.BookExceptionMessages.BookUpdated);
    }
}
