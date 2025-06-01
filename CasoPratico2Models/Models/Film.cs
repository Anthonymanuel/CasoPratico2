using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Film : ClaseBase
{
    [Key]
    [Column("film_id")]
    public int FilmId { get; set; }

    [Required]
    [MaxLength(128)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; } = string.Empty;

    [Column("release_year")]
    public int? ReleaseYear { get; set; }

    [Required]
    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("original_language_id")]
    public int? OriginalLanguageId { get; set; }

    [Required]
    [Column("rental_duration")]
    public byte RentalDuration { get; set; } = 3;

    [Required]
    [Column("rental_rate", TypeName = "decimal(4,2)")]
    public decimal RentalRate { get; set; } = 4.99m;

    [Column("length")]
    public int? Length { get; set; }

    [Required]
    [Column("replacement_cost", TypeName = "decimal(5,2)")]
    public decimal ReplacementCost { get; set; } = 19.99m;

    [MaxLength(10)]
    [Column("rating")]
    public string? Rating { get; set; } = "G";

    [Column("special_features")]
    public string? SpecialFeatures { get; set; }
}
