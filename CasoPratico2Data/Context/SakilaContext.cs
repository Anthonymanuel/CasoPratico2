
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
    public DbSet<Film> Film { get; set; }
    public DbSet<FilmActor> FilmActor { get; set; }
    public DbSet<FilmCategory> FilmCategory { get; set; }
    public DbSet<FilmText> FilmText { get; set; }
    public DbSet<Inventory> Inventory { get; set; }
    public DbSet<Language> Language { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Staff> Staff { get; set; }
       

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

        modelBuilder.Entity<Film>(entity =>
        {
            entity.ToTable("film");

            entity.HasKey(f => f.FilmId);

            entity.Property(f => f.FilmId)
                .HasColumnName("film_id");

            entity.Property(f => f.Title)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("title");

            entity.Property(f => f.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.Property(f => f.ReleaseYear)
                .HasColumnName("release_year");

            entity.Property(f => f.LanguageId)
                .IsRequired()
                .HasColumnName("language_id");

            entity.Property(f => f.OriginalLanguageId)
                .HasColumnName("original_language_id");

            entity.Property(f => f.RentalDuration)
                .IsRequired()
                .HasColumnName("rental_duration");

            entity.Property(f => f.RentalRate)
                .HasColumnType("decimal(4,2)")
                .HasColumnName("rental_rate");

            entity.Property(f => f.Length)
                .HasColumnName("length");

            entity.Property(f => f.ReplacementCost)
                .IsRequired()
                .HasColumnType("decimal(5,2)")
                .HasColumnName("replacement_cost");

            entity.Property(f => f.Rating)
                .HasMaxLength(10)
                .HasColumnName("rating");

            entity.Property(f => f.SpecialFeatures)
                .HasColumnName("special_features");
        });

        modelBuilder.Entity<FilmActor>(entity =>
        {
            entity.ToTable("film_actor");
            entity.HasKey(e => new { e.ActorId, e.FilmId });

            entity.Property(e => e.ActorId)
                .HasColumnName("actor_id");

            entity.Property(e => e.FilmId)
                .HasColumnName("film_id");
        });

        modelBuilder.Entity<FilmCategory>(entity =>
        {
            entity.ToTable("film_category");
            entity.HasKey(e => new { e.FilmId, e.CategoryId });

            entity.Property(e => e.FilmId)
                .HasColumnName("film_id");

            entity.Property(e => e.CategoryId)
                .HasColumnName("category_id");
        });

        modelBuilder.Entity<FilmText>(entity =>
        {
            entity.ToTable("film_text");

            entity.HasKey(e => e.FilmId);

            entity.Property(e => e.FilmId)
                .HasColumnName("film_id");

            entity.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("text");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("inventory");

            entity.HasKey(e => e.InventoryId)
                  .HasName("PRIMARY");

            entity.Property(e => e.InventoryId)
                  .HasColumnName("inventory_id");

            entity.Property(e => e.FilmId)
                  .IsRequired()
                  .HasColumnName("film_id");

            entity.Property(e => e.StoreId)
                  .IsRequired()
                  .HasColumnName("store_id");
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

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("payment"); 

            entity.HasKey(e => e.PaymentId)
                  .HasName("pk_payment_id");

            entity.Property(e => e.PaymentId)
                  .HasColumnName("payment_id");

            entity.Property(e => e.CustomerId)
                  .IsRequired()
                  .HasColumnName("customer_id");

            entity.Property(e => e.StaffId)
                  .IsRequired()
                  .HasColumnName("staff_id");

            entity.Property(e => e.RentalId)
                  .HasColumnName("rental_id");

            entity.Property(e => e.Amount)
                  .IsRequired()
                  .HasColumnName("amount")
                  .HasColumnType("decimal(5,2)");

            entity.Property(e => e.PaymentDate)
                  .IsRequired()
                  .HasColumnName("payment_date");

            entity.HasOne<Customer>()
                  .WithMany()
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<Staff>()
                  .WithMany()
                  .HasForeignKey(e => e.StaffId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<Rental>()
                  .WithMany()
                  .HasForeignKey(e => e.RentalId)
                  .OnDelete(DeleteBehavior.SetNull);
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

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.ToTable("staff");

            entity.HasKey(e => e.StaffId);

            entity.Property(e => e.StaffId).HasColumnName("staff_id");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(45)
                .HasColumnName("first_name");

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(45)
                .HasColumnName("last_name");

            entity.Property(e => e.AddressId)
                .IsRequired()
                .HasColumnName("address_id");

            entity.Property(e => e.Picture)
                .HasColumnType("blob")
                .HasColumnName("picture");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");

            entity.Property(e => e.StoreId)
                .IsRequired()
                .HasColumnName("store_id");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasColumnName("active");

            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("username");

            entity.Property(e => e.Password)
                .HasColumnType("varchar(40)")
                .HasColumnName("password");
   
            entity.HasOne<Address>() 
                .WithMany()
                .HasForeignKey(e => e.AddressId);

            entity.HasOne<Store>() 
                .WithMany()
                .HasForeignKey(e => e.StoreId);
        });

    }
}
