using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using BookStore.Application.DTO.AuthResponse;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application.Commands.Auth;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResponseDTO>
{
   
    private readonly IJwtTokenGenerator _tokenGenerator;

    private readonly IServiceScopeFactory _scopeFactory;

    public RegisterUserCommandHandler(IServiceScopeFactory scopeFactory, IJwtTokenGenerator tokenGenerator)
    {
        _scopeFactory = scopeFactory;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AuthResponseDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            var existingUser = await userManager.FindByEmailAsync(request.userDTO.Email);
            if (existingUser != null)
            {
                return new AuthResponseDTO(
                    Token: null,
                    RefreshToken: null,
                    TokenExpiration: DateTime.MinValue,
                    UserId: null,
                    Email: request.userDTO.Email,
                    Roles: new List<string>(),
                    IsSuccess: false,
                    Message: "Email je već registrovan."
                );
            }

            var newUser = new User
            {
                UserName = request.userDTO.Email, // Make sure to set UserName!
                Email = request.userDTO.Email,
                Name = request.userDTO.Name,
                Surname = request.userDTO.Surname
            };

            var createUserResult = await userManager.CreateAsync(newUser, request.userDTO.Password);

            if (!createUserResult.Succeeded)
            {
                var errors = string.Join("; ", createUserResult.Errors.Select(e => e.Description));
                return new AuthResponseDTO(
                    Token: null,
                    RefreshToken: null,
                    TokenExpiration: DateTime.MinValue,
                    UserId: null,
                    Email: request.userDTO.Email,
                    Roles: new List<string>(),
                    IsSuccess: false,
                    Message: errors
                );
            }

            var token = _tokenGenerator.GenerateToken(newUser);
            var roles = await userManager.GetRolesAsync(newUser);

            return new AuthResponseDTO(
                Token: token,
                RefreshToken: null,
                TokenExpiration: DateTime.UtcNow.AddHours(1),
                UserId: newUser.Id.ToString(),
                Email: newUser.Email,
                Roles: roles.ToList(),
                IsSuccess: true,
                Message: "Registracija uspešna."
            );
        }
    }

}
