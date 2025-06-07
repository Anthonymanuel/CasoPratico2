using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CasoPratico2Models.Models;

public class Address : ClaseBase
{
    public int AddressId { get; set; }
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string District { get; set; } = string.Empty;
    public int CityId { get; set; }
    public string? PostalCode { get; set; }
    public string Phone { get; set; } = string.Empty;

    public string? LocationWkt { get; set; }
    [JsonIgnore]
    [NotMapped]
    public Geometry? Location
    {
        get => LocationWkt == null ? null : new WKTReader().Read(LocationWkt);
        set => LocationWkt = value?.ToText();
    }
}
