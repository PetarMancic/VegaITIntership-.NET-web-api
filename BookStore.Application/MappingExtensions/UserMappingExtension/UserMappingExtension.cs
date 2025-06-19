using System.Runtime.CompilerServices;
using BookStore.Application.DTO.User;
using BookStore.Domain.Entities;

namespace BookStore.Application.MappingExtensions.UserMappingExtension;
public static  class UserMappingExtension
{

    public static User ToDomainUser(this NewUserDTO userDto)
    {
        return new User
        {
            Name = userDto.Name,
            Surname = userDto.Surname,
            UserName = userDto.Username,
            Email = userDto.Email,
            HashedPassword = userDto.Password
        };
    }

    //public static NewUserResponseDTO ToNewUserDto( this User user)
    //{
    //    return new NewUserResponseDTO
    //    {
    //        Id = user.Id,
    //        Name = user.Name,
    //        Surname = user.Surname,
    //        Email = user.Email,
    //        Password = user.HashedPassword
    //    };
    //}
}
