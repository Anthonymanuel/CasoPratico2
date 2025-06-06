﻿using CasoPratico2Data.Context;
using CasoPratico2Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace CasoPratico2Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<SakilaContext>();
        services.AddTransient<IActorRepository, ActorRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<ICountryRepository, CountryRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IFilmRepository, FilmRepository>();
        services.AddTransient<IFilmActorRepository, FilmActorRepository>();
        services.AddTransient<IFilmCategoryRepository, FilmCategoryRepository>();
        services.AddTransient<IFilmTextRepository, FilmTextRepository>();
        services.AddTransient<IInventoryRepository, InventoryRepository>();
        services.AddTransient<ILanguageRepository, LanguageRepository>();
        services.AddTransient<IPaymentRepository, PaymentRepository>();
        services.AddTransient<IRentalRepository, RentalRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IStaffRepository, StaffRepository>();
        services.AddTransient<IStoreRepository, StoreRepository>();
        return services;
    }
}