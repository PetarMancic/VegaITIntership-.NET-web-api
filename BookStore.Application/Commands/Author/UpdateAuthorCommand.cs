using Bookstore.Domain.DTO;
using Bookstore.Domain.DTO.AuthorDtos;
using MediatR;

namespace BookStore.Application.Commands;
public sealed record  UpdateAuthorCommand( int authorId, UpdateAuthorDTO updateAuthorDto) : IRequest<BaseOperationResultDTO> ;


