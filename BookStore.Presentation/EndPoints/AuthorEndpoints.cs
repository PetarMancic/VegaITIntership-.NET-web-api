using Bookstore.Domain.DTO.AuthorDtos;
using BookStore.Application.Commands;
using BookStore.Application.Queries;
using MediatR;

namespace Bookstore.Presentation.EndPoints;
public static class AuthorEndpoints
{
    public const string Base = "api/authors"; // => TODO: extract prop to interface
    
    public static void MapAuthorEndpoints(this WebApplication app  )
    {
        var authorsGroup= app.MapGroup(Base);

        authorsGroup.MapPost(string.Empty, AddAuthor);
        authorsGroup.MapGet("{authorId}", GetAuthorById);
        authorsGroup.MapGet("", GetAllAuthors);
        authorsGroup.MapPut("{authorId}", UpdateAuthor);
        authorsGroup.MapDelete("{authorId}", DeleteAuthor);
    }
    private static async Task<IResult> AddAuthor( AddAuthorDTO addAuthorDTO, ISender mediator)
    {
        var result= await mediator.Send(new CreateAuthorCommand(addAuthorDTO));
        return Results.Ok(result);
    }
    private static async Task<IResult> GetAuthorById(int authorId, IMediator mediator)
    {
        var result= await mediator.Send(new GetAuthorByIdQuery(authorId));
        return Results.Ok(result);
    }
    private static async Task<IResult> GetAllAuthors(IMediator mediator)
    {
        var result= await mediator.Send(new GetAllAuthorsQuery());
        return Results.Ok(result);
    }
    private static async Task<IResult> UpdateAuthor(
        int authorId, 
        UpdateAuthorDTO updateAuthor, 
        IMediator mediator)
    {
        var result= await mediator.Send(new UpdateAuthorCommand(authorId, updateAuthor));
        return Results.Ok(result);
    }
    private static async Task<IResult> DeleteAuthor(int authorId, bool hardDelete, IMediator mediator)
    {
       var result= await mediator.Send(new DeleteAuthorCommand(authorId, hardDelete));
       return Results.Ok(result);
    }
}
