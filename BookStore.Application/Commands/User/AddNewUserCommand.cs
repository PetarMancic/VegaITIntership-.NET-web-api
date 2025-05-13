using BookStore.Application.DTO.User;
using MediatR;

namespace BookStore.Application.Commands.User;

public record  AddNewUserCommand(NewUserDTO userDTO): IRequest<NewUserResponseDTO>;

