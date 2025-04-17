namespace Bookstore.Domain.DTO.AuthorDtos;
public sealed record GetAuthorDTO(int Id, string Name, string Surname, string Adrress, DateTime CreatedAt, DateTime? UpdatedAt, DateTime DeletedAt,List<BookDTO> Books);



