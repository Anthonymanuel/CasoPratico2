using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Category : ClaseBase
{
    [Key]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [MaxLength(25)]
    public string Name { get; set; } = string.Empty;

}
