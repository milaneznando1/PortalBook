using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC;

public static class InjectionDepencencySetup
{
    public static void AddDependencyInjectionSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        Bootstrapper.RegisterServices(services);
    }
}