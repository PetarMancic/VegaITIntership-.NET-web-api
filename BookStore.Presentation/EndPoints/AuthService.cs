using BookStore.Application.DTO.AuthResponse;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Presentation.EndPoints;

public class AuthService : IAuthService
{
   // private readonly ITokenService _token
    public Task<AuthResponseDTO> LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }
}
