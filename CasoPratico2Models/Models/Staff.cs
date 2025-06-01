using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Staff
{
    [Key]
    [Column("staff_id")]
    public byte StaffId { get; set; } 

    [Required]
    [MaxLength(45)]
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(45)]
    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [Column("address_id")]
    public int AddressId { get; set; } 

    [Column("picture", TypeName = "blob")]
    public byte[]? Picture { get; set; }  

    [MaxLength(50)]
    public string? Email { get; set; }

    [Required]
    [Column("store_id")]
    public byte StoreId { get; set; }  

    [Required]
    public bool Active { get; set; } 

    [Required]
    [MaxLength(16)]
    public string Username { get; set; } = string.Empty;

    [Column(TypeName = "varchar(40)")]
    public string? Password { get; set; } 
}
