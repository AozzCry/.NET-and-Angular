using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesAndEmployees.dotnet_api.Models;

public class Company
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    [ForeignKey("Address")]
    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public List<Company>? Employees { get; set; }

    public DateTime CreatedDate { get; set; }

}
