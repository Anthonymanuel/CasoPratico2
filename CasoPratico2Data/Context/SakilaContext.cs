
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
    public DbSet<City> City { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Language> Language { get; set; }
    public DbSet<Category> Category { get; set; }

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

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
