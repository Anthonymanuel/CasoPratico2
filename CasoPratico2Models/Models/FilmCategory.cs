using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class FilmCategory
{
    [Key, Column("film_id", Order = 0)]
    public int FilmId { get; set; }

    [Key, Column("category_id", Order = 1)]
    public int CategoryId { get; set; }
}
