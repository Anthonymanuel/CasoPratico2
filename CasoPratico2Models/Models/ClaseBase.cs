using System.ComponentModel.DataAnnotations.Schema;

namespace CasoPratico2Models.Models;

public class ClaseBase
{
    [Column("last_update")]
    public DateTime LatUpdate { get; set; }
}
