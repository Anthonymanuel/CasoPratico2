using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoPratico2Models.Models;

public class Actor : ClaseBase
{
    [Column("actor_id")]
    [Key]
    public int ActorId { get; set; }

    [Column("first_name")]
    [MaxLength(45)]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")]
    [MaxLength(45)]
    public string LastName { get; set; } = string.Empty;
}
