using System.Reflection;
using BookStore.Domain.Entities;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceCollection
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
       services.AddMediatR(Assembly.GetExecutingAssembly());
       
    }
}