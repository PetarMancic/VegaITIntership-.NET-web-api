using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceCollection
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
       services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}