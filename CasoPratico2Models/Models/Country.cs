using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoPratico2Models.Models;

public class Country : ClaseBase
{
    [Key]
    [Column("country_id")]
    public int CountryId { get; set; } 

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
}
