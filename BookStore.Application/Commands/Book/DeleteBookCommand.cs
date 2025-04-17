using Bookstore.Domain.DTO;
using MediatR;

namespace BookStore.Application.Commands.Books;
public sealed record  DeleteBookCommand(int bookId, bool hardDelete): IRequest<BaseOperationResultDTO>;
