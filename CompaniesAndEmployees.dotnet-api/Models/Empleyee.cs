using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesAndEmployees.dotnet_api.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    [ForeignKey("Address")]
    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    [ForeignKey("Company")]
    public int? CompanyId { get; set; }
    public Company? Company { get; set; }

    public DateTime CreatedDate { get; set; }
}
