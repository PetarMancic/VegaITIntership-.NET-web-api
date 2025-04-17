using Microsoft.AspNetCore.Diagnostics;
using Bookstore.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Infrastructure.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler( ILogger<GlobalExceptionHandler> logger)
    {
       
        _logger = logger;
    }
    public  async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {

       
        try{
        _logger.LogError(exception, "An error occurred while processing the request.");

        // Map exception to status code and title
        var (statusCode, title) = MapException(exception);

        // Create ProblemDetails response
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };

        // Configure response
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true; // Indicates the exception was handled
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while handling the exception.");
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsync("An error occurred while processing the exception.");
            return false;
        }
    }
    private (int statusCode, string title) MapException(Exception exception)
    {
        return exception switch
        {
            BookNotFoundException=>(StatusCodes.Status404NotFound, "Book is not found"),
            AuthorNotFoundExcpetion=>(StatusCodes.Status404NotFound, "Author is not found"),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error-global exception")
        };
    }
           
}
