using CasoPratico2Data.Context;
using CasoPratico2Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace CasoPratico2Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<SakilaContext>();
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<ICountryRepository, CountryRepository>();
        services.AddTransient<ILanguageRepository, LanguageRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();

        return services;
    }
}