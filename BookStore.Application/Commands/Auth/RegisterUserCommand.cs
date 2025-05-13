using BookStore.Application.DTO.AuthResponse;
using MediatR;

namespace BookStore.Application.Commands.Auth;

public record RegisterUserCommand(RegisterRequestDTO userDTO): IRequest<AuthResponseDTO>;

