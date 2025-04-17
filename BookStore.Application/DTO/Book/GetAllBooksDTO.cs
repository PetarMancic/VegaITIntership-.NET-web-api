
using Bookstore.Domain.DTO.AuthorDtos;

namespace Bookstore.Models.DTO.Bookstore;
public sealed record GetAllBooksDTO(int Id, string Title, AuthorWithoutBooksDTO AuthorWithoutBooksDTO);