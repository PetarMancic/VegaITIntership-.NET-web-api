using Bookstore.Domain.DTO.AuthorDtos;
using MediatR;
namespace BookStore.Application.Queries;
public record GetAuthorByIdQuery(int authorId): IRequest<GetAuthorDTO?> {};
