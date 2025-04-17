using Bookstore.Domain.DTO;
using Bookstore.Domain.DTO.Book;
using BookStore.Application.Commands.Books;
using BookStore.Application.Queries;
using MediatR;

namespace Bookstore.Presentation.EndPoints;
public  static class BookEndpoints
{
    public const string Base = "api/books";
    public static void MapBookEndpoints( this WebApplication app)
    {
        var booksGroup = app.MapGroup(Base);

        booksGroup.MapPost("",AddNewBook);
        booksGroup.MapGet("{bookId}", GetBookById);
        booksGroup.MapGet("", GetAllBooks);
        booksGroup.MapPut("{bookId}",UpdateBook);
        booksGroup.MapDelete("bookId", DeleteBook);
    }
    private static async Task<IResult> AddNewBook(AddBookDTO bookDto,IMediator mediator )
    {
        var result= await mediator.Send(new CreateBookCommand(bookDto));
        return Results.Ok(result);
    }
    private static async Task<IResult> GetBookById(int bookId,IMediator mediator )
    {
        var result= await mediator.Send(new GetBookByIdQuery(bookId));
        return Results.Ok(result);
    }
    private static async Task<IResult> GetAllBooks(IMediator mediator )
    {
        var result= await mediator.Send(new GetAllBooksQuery());
        return Results.Ok(result);
    }
    private static async Task<IResult> UpdateBook(int bookId, UpdateBookDTO updatebook, IMediator mediator)
    {
        var result= await mediator.Send(new UpdateBookCommand(updatebook,bookId));
        return Results.Ok(result);
    }
    private static async Task<IResult> DeleteBook(int bookId, bool hardDelete, IMediator mediator)
    {
        var result= await mediator.Send(new DeleteBookCommand(bookId,hardDelete));
        return Results.Ok(result);
    }
}
