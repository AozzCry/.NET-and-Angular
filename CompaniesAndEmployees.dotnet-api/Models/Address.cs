using System.ComponentModel.DataAnnotations;

namespace CompaniesAndEmployees.dotnet_api.Models;

public class Address
{
    [Key]
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? StreetNumber { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
}
