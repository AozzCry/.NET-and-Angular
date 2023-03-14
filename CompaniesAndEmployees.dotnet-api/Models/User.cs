using System.ComponentModel.DataAnnotations;

namespace CompaniesAndEmployees.dotnet_api.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string? Email { get; set; }
    public string? Password { get; set; }

    public RoleValue Role { get; set; } = RoleValue.User;
}