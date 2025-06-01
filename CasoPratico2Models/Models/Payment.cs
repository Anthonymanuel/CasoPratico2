using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Payment : ClaseBase
{
    [Key]
    [Column("payment_id")]
    public int PaymentId { get; set; } 

    [Required]
    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Required]
    [Column("staff_id")]
    public int StaffId { get; set; } 

    [Column("rental_id")]
    public int? RentalId { get; set; } 

    [Required]
    [Column("amount", TypeName = "decimal(5,2)")]
    public decimal Amount { get; set; }

    [Required]
    [Column("payment_date")]
    public DateTime PaymentDate { get; set; }
}
