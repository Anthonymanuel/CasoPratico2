using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoPratico2Models.Models;

public class Customer
{
    [Key]
    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("store_id")]
    public byte StoreId { get; set; }  

    [Required]
    [MaxLength(45)]
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty; 

    [Required]
    [MaxLength(45)]
    [Column("last_name")]
    public string LastName { get; set; } = string.Empty; 

    [MaxLength(50)]
    public string? Email { get; set; }

    [Column("address_id")]
    public int AddressId { get; set; }

    [Column("active")]
    public bool Active { get; set; } = true;

    [Column("create_date")]
    public DateTime CreateDate { get; set; }   = DateTime.Now;
}
