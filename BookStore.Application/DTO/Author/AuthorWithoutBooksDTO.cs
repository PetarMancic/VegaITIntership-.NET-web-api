namespace Bookstore.Domain.DTO.AuthorDtos;
public sealed record AuthorWithoutBooksDTO(string Name, string Surname, string Country,DateTime CreatedAt, DateTime UpdatedAt);

