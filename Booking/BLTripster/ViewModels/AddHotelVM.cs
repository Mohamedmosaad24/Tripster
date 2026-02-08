using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

public class AddHotelVM
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    [Required]
    public string Address { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    // الصور (حد أقصى 5)
    [Required]
    public List<IFormFile> Images { get; set; } = new();
}
