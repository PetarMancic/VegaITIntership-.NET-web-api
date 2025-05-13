

using BookStore.Application.DTO.User;
using MediatR;

namespace BookStore.Application.Commands.User;

public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, NewUserResponseDTO>
{
    public Task<NewUserResponseDTO> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
