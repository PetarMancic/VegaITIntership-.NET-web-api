using Bookstore.Domain.DTO;
using MediatR;

namespace BookStore.Application.Commands;
public sealed record  DeleteAuthorCommand(int authorId, bool hardDelete): IRequest<BaseOperationResultDTO> ;


