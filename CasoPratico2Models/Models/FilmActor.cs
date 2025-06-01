using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class FilmActor : ClaseBase
{
    [Key, Column("actor_id", Order = 0)]
    public int ActorId { get; set; }

    [Key, Column("film_id", Order = 1)]
    public int FilmId { get; set; }
}
