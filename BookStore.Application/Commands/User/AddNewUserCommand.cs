using BookStore.Application.DTO.User;
using MediatR;

namespace BookStore.Application.Commands.Users;

public record  AddNewUserCommand(NewUserDTO userDTO): IRequest<NewUserResponseDTO>;

