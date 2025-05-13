using BookStore.Application.DTO.AuthResponse;

namespace BookStore.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDTO> LoginAsync(string email, string password);

}
