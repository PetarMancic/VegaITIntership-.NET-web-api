

namespace BookStore.Application.DTO.User;
//TODO @Petar-> refactor there record
public sealed record NewUserResponseDTO(int Id, string Name, string Surname, string Email, string Password);
