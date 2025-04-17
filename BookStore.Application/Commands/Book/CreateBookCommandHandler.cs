using Bookstore.Domain.Entities;
using Bookstore.Domain.Exceptions;
using Bookstore.MappingExtensions.BookMapingExtension;
using Bookstore.Models.DTO.Book;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Commands.Books;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, GetBookDTO?>
{
    private readonly IGenericRepository<Book> _bookRepo;
    private readonly IGenericRepository<Author> _authorRepo;
    
    
    public CreateBookCommandHandler( IGenericRepository<Book> bookRepo, IGenericRepository<Author> authorRepo)
    {
        _bookRepo = bookRepo;
        _authorRepo = authorRepo; 
    }
    public async Task<GetBookDTO?> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var existingAuthor =  await _authorRepo.GetByIdAsync(request.AddBookDTO.AuthorId);
        if (existingAuthor is null)
        {
           throw new BookNotFoundException(request.AddBookDTO.AuthorId);
        }
        var book= request.AddBookDTO.toBookDTO(existingAuthor);
        await _bookRepo.AddAsync(book);

        return  book.ToGetBookDTO();
    }
}
