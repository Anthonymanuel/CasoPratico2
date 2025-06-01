using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Store : ClaseBase
{
    [Key]
    [Column("store_id")]
    public byte StoreId { get; set; } 

    [Required]
    [Column("manager_staff_id")]
    public int ManagerStaffId { get; set; }  

    [Required]
    [Column("address_id")]
    public int AddressId { get; set; } 
}
