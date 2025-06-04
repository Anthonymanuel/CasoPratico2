using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CasoPratico2Models.Models;

public class City : ClaseBase
{

    public int CityId { get; set; }


    public string CityName { get; set; } = string.Empty;


    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    [JsonIgnore]
    public Country? Country { get; set; }
}
