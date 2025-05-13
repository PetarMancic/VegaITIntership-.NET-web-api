using BookStore.Application.Commands.Auth;
using BookStore.Application.DTO.AuthResponse;
using BookStore.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.EndPoints;

public static class AuthEndPoints
{
    public const string Base = "api/auth";

    public static void MapAuthEndPoints( this WebApplication app)
    {
        var authGroup = app.MapGroup(Base);

        authGroup.MapPost("/register", RegisterUser);
        //authGroup.MapPost("/login",LoginUser);

    }

    private static async Task<IResult> RegisterUser([FromBody] RegisterRequestDTO request,ISender mediator)
    {
        var result = await mediator.Send(new RegisterUserCommand(request));
        return Results.Ok(result);
    }

    //private static async Task<IResult> LoginUser(
    //    [FromBody] LoginRequest request,
    //    [FromServices] IAuthService authService)
    //{
    //    var result = await authService.LoginAsync(request);
    //    if (!result.Success)
    //        return Results.Unauthorized();
    //    return Results.Ok(result);
    //}
}
