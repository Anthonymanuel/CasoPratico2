using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoPratico2Models.Models;

public class Customer : ClaseBase
{
    public int CustomerId { get; set; }
    public byte StoreId { get; set; }  
    public string FirstName { get; set; } = string.Empty; 
    public string LastName { get; set; } = string.Empty; 
    public string? Email { get; set; }
    public int AddressId { get; set; }
    public bool Active { get; set; } = true;

}
