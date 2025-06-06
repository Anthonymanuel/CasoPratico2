
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CasoPratico2Data.Context;

public class SakilaContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public SakilaContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("default");
    }

    public DbSet<Actor> Actor { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Language> Language { get; set; }
    public DbSet<Category> Category { get; set; }

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
        _connectionString,
        ServerVersion.AutoDetect(_connectionString),
        mySqlOptions => mySqlOptions.UseNetTopologySuite()
    );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Actor>(entity =>
        {

            entity.HasKey(e => e.ActorId);

            entity.Property(e => e.ActorId)
                  .HasColumnName("actor_id");

            entity.Property(e => e.FirstName)
                  .HasColumnName("first_name")
                  .HasMaxLength(45);

            entity.Property(e => e.LastName)
                  .HasColumnName("last_name")
                  .HasMaxLength(45);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.Property(e => e.AddressId)
                .HasColumnName("address_id");

            entity.Property(e => e.AddressLine1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("address");

            entity.Property(e => e.AddressLine2)
                .HasMaxLength(50)
                .HasColumnName("address2");

            entity.Property(e => e.District)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("district");

            entity.Property(e => e.CityId)
                .IsRequired()
                .HasColumnName("city_id");

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postal_code");

            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.Property(e => e.Location)
                .IsRequired()
                .HasColumnName("location");

           entity
            .Ignore(a => a.Location);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId);

            entity.Property(e => e.CityId)
                  .HasColumnName("city_id");

            entity.Property(e => e.CityName)
                .HasColumnName("city")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.CountryId)
                .HasColumnName("country_id")
                .IsRequired();

            entity.HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_City_Country");
        });
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId);

            entity.Property(e => e.CountryId)
                  .HasColumnName("country_id");

            entity.Property(e => e.CountryId)
                .HasColumnName("country_id");

            entity.Property(e => e.Name)
                .HasColumnName("country")
                .HasMaxLength(50)
                .IsRequired();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");

            entity.HasKey(e => e.CustomerId);
            entity.Property(e => e.CustomerId)
                  .HasColumnName("customer_id");

            entity.Property(e => e.StoreId)
                  .HasColumnName("store_id");

            entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(45)
                  .HasColumnName("first_name");

            entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(45)
                  .HasColumnName("last_name");

            entity.Property(e => e.Email)
                  .HasMaxLength(50)
                  .HasColumnName("email");

            entity.Property(e => e.AddressId)
                  .HasColumnName("address_id");

            entity.Property(e => e.Active)
                  .HasColumnName("active")
                  .HasDefaultValue(true);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("language");

            entity.HasKey(e => e.LanguageId);

            entity.Property(e => e.LanguageId)
                .HasColumnName("language_id")
                .IsRequired();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(20)
                .IsRequired();

        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");

            entity.HasKey(e => e.CategoryId); 

            entity.Property(e => e.CategoryId)
                .HasColumnName("category_id")
                .IsRequired();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(25)
                .IsRequired();
   
        });

    }
}
