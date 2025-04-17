using Bookstore.Domain.DTO.Author;
using Bookstore.Domain.DTO.AuthorDtos;
using MediatR;

namespace BookStore.Application.Commands;
public record  CreateAuthorCommand(AddAuthorDTO author) :IRequest<NewAuthorDTO>;