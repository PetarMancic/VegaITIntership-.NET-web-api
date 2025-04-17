
using Bookstore.Models.DTO.Book;
using MediatR;

namespace BookStore.Application.Queries;
public sealed record  GetBookByIdQuery(int bookId): IRequest<GetBookDTO>;

