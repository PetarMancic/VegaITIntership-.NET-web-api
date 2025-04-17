using Bookstore.Domain.DTO.AuthorDtos;
namespace Bookstore.Models.DTO.Book;
public sealed record GetBookDTO (int Id, string Title,float Price, DateTime CreatedAt, DateTime UpdatedAt,  AuthorWithoutBooksDTO Author);
