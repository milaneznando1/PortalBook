using Application.Services;
using Application.Services.Interfaces;
using Infra.Repositories;
using Infra.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC;

public static class Bootstrapper
{
    public static void RegisterServices(IServiceCollection serviceCollection)
    {
        //Services
        serviceCollection.AddScoped<IBookService, BookService>();

        //Repos
        serviceCollection.AddScoped<IBookRepository, BookRepository>();
    }
}