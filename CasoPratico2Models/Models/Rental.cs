using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Rental : ClaseBase
{
    public int RentalId { get; set; } 
    public DateTime RentalDate { get; set; }  
    public int InventoryId { get; set; }  
    public int CustomerId { get; set; }  
    public DateTime? ReturnDate { get; set; } 
    public byte StaffId { get; set; }  

}
