using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Inventory : ClaseBase
{
    public int InventoryId { get; set; }

    public int FilmId { get; set; }

    public byte StoreId { get; set; }

}
