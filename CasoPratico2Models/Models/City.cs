using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoPratico2Models.Models;

public class City : ClaseBase
{
    [Key] public int Id { get; set; }
    public int CityId { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("city")]
    public string CityName { get; set; } = string.Empty;

    [Required]
    [Column("country_id")]
    public int CountryId { get; set; }
}
