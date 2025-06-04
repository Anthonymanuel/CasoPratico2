using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoPratico2Models.Models;

public class Country : ClaseBase
{
    public int CountryId { get; set; } 

    public string Name { get; set; } = string.Empty;
}
