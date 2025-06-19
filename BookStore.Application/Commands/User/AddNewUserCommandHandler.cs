using Bookstore.Domain.Exceptions;
using BookStore.Application.DTO.User;
using BookStore.Application.Interfaces;
using BookStore.Application.MappingExtensions.UserMappingExtension;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Commands.Users;

public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, NewUserResponseDTO>
{

    private readonly IGenericRepository<User> _userRepo;
    private readonly IJwtTokenGenerator _jwtGenerator;

    public AddNewUserCommandHandler(IGenericRepository<User> userRepo, IJwtTokenGenerator jwtGenerator)
    {
        _userRepo = userRepo;
        _jwtGenerator = jwtGenerator;
    }
    public async  Task<NewUserResponseDTO> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = request.userDTO;
        var userDomain = request.userDTO.ToDomainUser();

        var existingUserEmail = await _userRepo.FindByAsync(u => u.Email == userEntity.Email);
        if( existingUserEmail.Any() )
        {
            //TODO => Make another exception for user
            throw new AuthorNotFoundExcpetion(1);
        }


        await _userRepo.AddAsync(userDomain);
        var token = _jwtGenerator.GenerateToken(userDomain);

        return null;
       // return userDomain.


    }
}
