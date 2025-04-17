using Bookstore.Domain.DTO;
using Bookstore.Domain.DTO.Book;
using MediatR;

namespace BookStore.Application.Commands.Books;
public sealed record  UpdateBookCommand(UpdateBookDTO updateBookDto, int bookId) :IRequest<BaseOperationResultDTO>;