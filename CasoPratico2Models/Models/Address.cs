using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoPratico2Models.Models;

public class Address : ClaseBase
{
    [Key]
    [Column("address_id")]
    public int AddressId { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("address")]
    public string AddressLine1 { get; set; } = string.Empty;

    [Column("address2")]
    [MaxLength(50)]
    public string? AddressLine2 { get; set; }

    [Required]
    [Column("district")]
    [MaxLength(20)]
    public string District { get; set; } = string.Empty;

    [Required]
    [Column("city_id")]
    public int CityId { get; set; }

    [Column("postal_code")]
    [MaxLength(10)]
    public string? PostalCode { get; set; }

    [Required]
    [Column("phone")]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [Column("")]
    public Geometry Location { get; set; }      
}
