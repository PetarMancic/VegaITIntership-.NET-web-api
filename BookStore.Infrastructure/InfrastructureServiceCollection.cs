using Bookstore.Infrastructure;
using Bookstore.Infrastructure.Repository;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookStore.Infrastructure;

public static class InfrastructureServiceCollection
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {

        //services.AddIdentity<User, IdentityRole>(options =>
        //{
        //    // Configure Identity options (customize as needed)
        //    options.Password.RequireDigit = true;
        //    options.Password.RequiredLength = 6;
        //    options.Password.RequireNonAlphanumeric = false;
        //    options.User.RequireUniqueEmail = true;
        //})
        //    .AddEntityFrameworkStores<BookStoreDbContext>()
        //    .AddDefaultTokenProviders();

        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        // servicec.AddScopen<IUser>();
        //services.AddScoped<IUser, UserManager>();
        services.AddLogging(loggingBuilder=>
        {
            loggingBuilder.AddConsole();
            loggingBuilder.AddDebug();
        });

        services.AddDbContext<BookStoreDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString(ConstantsInfrastructure.PostgreConfiguration.BookstoreDbConnectionName)));
        
    } 
}
