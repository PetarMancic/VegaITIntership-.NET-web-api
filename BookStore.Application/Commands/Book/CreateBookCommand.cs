
using Bookstore.Domain.DTO;
using Bookstore.Models.DTO.Book;
using MediatR;

namespace BookStore.Application.Commands.Books;
public sealed record  CreateBookCommand(AddBookDTO AddBookDTO) :IRequest<GetBookDTO>;
