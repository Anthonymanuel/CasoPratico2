using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Inventory : ClaseBase
{
    [Key]
    [Column("inventory_id")]
    public int InventoryId { get; set; }

    [Required]
    [Column("film_id")]
    public int FilmId { get; set; }

    [Required]
    [Column("store_id")]
    public byte StoreId { get; set; }
}
