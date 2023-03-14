namespace CompaniesAndEmployees.dotnet_api.Models;

public class LoginResponse
{
    public string? Token { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int UserId { get; set; }
    public string? Email { get; set; }
}
