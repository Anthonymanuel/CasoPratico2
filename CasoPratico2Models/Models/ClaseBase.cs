using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CasoPratico2Models.Models;

public class ClaseBase
{
    [Column("last_update")]
    [JsonPropertyName("last_update")]
    
    public DateTime LatUpdate { get; set; } = DateTime.UtcNow;
}
