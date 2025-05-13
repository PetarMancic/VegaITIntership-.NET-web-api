using Bookstore.Infrastructure.Middleware;

namespace BookStore.Presentation;
public static class PresentationServiceCollection
{
    public static void AddPresentationLayer( this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        
       
    }
}
