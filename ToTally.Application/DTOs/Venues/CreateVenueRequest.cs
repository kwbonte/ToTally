using System.ComponentModel.DataAnnotations;

namespace ToTally.Application.DTOs.Venues;

public sealed class CreateVenueRequest
{
    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string StateOrCountry { get; set; } = string.Empty;

    [Range(-90, 90)]
    public decimal? Latitude { get; set; }

    [Range(-180, 180)]
    public decimal? Longitude { get; set; }

    public bool IsDome { get; set; }

    public bool IsNeutralSiteCapable { get; set; }
}