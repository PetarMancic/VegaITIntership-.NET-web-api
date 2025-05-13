namespace BookStore.Application.DTO.User;

public sealed  record NewUserDTO (string Name, string Surname, string Email, string Password);
