using Bookstore.Domain.DTO;
using MediatR;

namespace BookStore.Application.Queries;
public sealed record  GetAllBooksQuery : IRequest<IEnumerable<BookDTO>>;