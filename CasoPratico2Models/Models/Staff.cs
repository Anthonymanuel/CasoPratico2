namespace CasoPratico2Models.Models;

public class Staff
{
    public byte StaffId { get; set; } 
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int AddressId { get; set; } 
    public byte[]? Picture { get; set; }  
    public string? Email { get; set; }
    public byte StoreId { get; set; }  
    public bool Active { get; set; } 
    public string Username { get; set; } = string.Empty;
    public string? Password { get; set; } 
}
