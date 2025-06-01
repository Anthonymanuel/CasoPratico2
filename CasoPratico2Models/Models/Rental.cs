using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Rental : ClaseBase
{
    [Key]
    [Column("rental_id")]
    public int RentalId { get; set; } 

    [Required]
    [Column("rental_date")]
    public DateTime RentalDate { get; set; }  

    [Required]
    [Column("inventory_id")]
    public int InventoryId { get; set; }  

    [Required]
    [Column("customer_id")]
    public int CustomerId { get; set; }  

    [Column("return_date")]
    public DateTime? ReturnDate { get; set; } 

    [Required]
    [Column("staff_id")]
    public byte StaffId { get; set; }  

}
