using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Payment : ClaseBase
{
    public int PaymentId { get; set; } 
    public int CustomerId { get; set; }
    public byte StaffId { get; set; } 
    public int? RentalId { get; set; } 
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
}
