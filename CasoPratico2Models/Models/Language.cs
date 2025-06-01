using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Language
{
    [Key]
    [Column("language_id")]
    public int LanguageId { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("name", TypeName = "char(20)")]
    public string Name { get; set; } = string.Empty;
}
