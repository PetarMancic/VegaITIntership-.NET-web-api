using Bookstore.Domain.DTO.Author;
using MediatR;

namespace BookStore.Application.Queries;
public sealed record  GetAllAuthorsQuery() :IRequest<IEnumerable<NewAuthorDTO>>;

