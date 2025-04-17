
using Bookstore.Domain.DTO;
using Bookstore.MappingExtensions.BookMapingExtension;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Queries;
public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDTO>>
{
    private readonly IGenericRepository<Book> _bookRepo;
    public GetAllBooksQueryHandler(IGenericRepository<Book> bookRepo)
    {
        _bookRepo=bookRepo;
    }
    public async Task<IEnumerable<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var allBooks= await _bookRepo.GetAllAsync();
        return allBooks.Select(book=> book.ToBookDto()).ToList();
    }
}

