using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class FilmText
{
    [Key]
    [Column("film_id")]
    public int FilmId { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }
}
