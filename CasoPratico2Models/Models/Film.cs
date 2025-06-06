using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Film : ClaseBase
{
    public int FilmId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public int? ReleaseYear { get; set; }
    public int LanguageId { get; set; }
    public int? OriginalLanguageId { get; set; }
    public byte RentalDuration { get; set; } = 3;
    public decimal RentalRate { get; set; } = 4.99m;
    public int? Length { get; set; }
    public decimal ReplacementCost { get; set; } = 19.99m;
    public string? Rating { get; set; } = "G";
    public string? SpecialFeatures { get; set; }
}
