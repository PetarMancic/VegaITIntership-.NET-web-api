using Bookstore.Domain.DTO;
using Bookstore.Domain.DTO.AuthorDtos;
using Bookstore.Domain.Entities;
using Bookstore.Models.DTO.Book;


namespace Bookstore.MappingExtensions.BookMapingExtension;
public static class BookMapingExtensions
{
    /// <summary>
    ///  Converts a <see cref="Book"/> entity to a simplified <see cref="BookDTO"/> containing only ID and title.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> entity to convert.</param>
    /// A new <see cref="BookDTO"/> instance containing only the book's ID and title.
     public static BookDTO ToBookDto(this Book book)
    {
        return new BookDTO(book.Id, book.Title, book.CreatedAt, book.UpdatedAt);
    }
    /// <summary>
    /// Converts a <see cref="Book"/> entity to a detailed <see cref="GetBookDTO"/> including author information.
    /// </summary>
    /// <param name="book"></param>
    ///A new <see cref="GetBookDTO"/> instance containing whole <see cref="Author"/> object.
    public static GetBookDTO ToGetBookDTO( this Book book)
    {
        return new GetBookDTO
        (
            book.Id,
            book.Title,
            book.Price,
            book.CreatedAt,
            book.UpdatedAt,
            ToAuthorWithoutBooksDTO(book.Author)
        );
    }
    public static AuthorWithoutBooksDTO  ToAuthorWithoutBooksDTO(this Author author )
    {
        return new AuthorWithoutBooksDTO(
            author.Name,
            author.Surname,
            author.Country,
            author.CreatedAt,
            author.UpdatedAt
        );
    }
    public static void ToUpdateBookDTO(this Book book, string newTitle)
    {
        book.Title= newTitle;
      
    }
    
    public static Book toBookDTO(this AddBookDTO addBookDTO, Author author)
    {
        return new Book 
        {
            Title= addBookDTO.Title,
            Author=author
        };
    }
}



        

