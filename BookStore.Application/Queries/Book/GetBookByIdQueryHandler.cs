
using Bookstore.Domain.Exceptions;
using Bookstore.MappingExtensions.BookMapingExtension;
using Bookstore.Models.DTO.Book;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Queries;
public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookDTO?>
{
    private readonly IGenericRepository<Book> _bookRepo;
    public GetBookByIdQueryHandler(IGenericRepository<Book> bookRepo)
    {
        _bookRepo=bookRepo;
    }
    public async Task<GetBookDTO?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
         var book= await _bookRepo.GetByIdWithIncludesAsync(request.bookId, book=> book.Author);
        if(book is null)
        {
            throw new BookNotFoundException(request.bookId);
        }

        return book.ToGetBookDTO();
    }
}

