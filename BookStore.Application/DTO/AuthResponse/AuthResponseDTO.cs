namespace BookStore.Application.DTO.AuthResponse;

public sealed record  AuthResponseDTO(string Token,
    string RefreshToken,
    DateTime TokenExpiration,
    string UserId,
    string Email,
    IReadOnlyList<string> Roles,
    bool IsSuccess,
    string Message = ""
);
