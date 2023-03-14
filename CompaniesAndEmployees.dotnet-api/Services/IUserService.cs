using CompaniesAndEmployees.dotnet_api.Models;

public interface IUserService
{
    public Task Create(UserRegistrationVm newUserVm);
    public Task<User?> IsExist(UserLoginVm userLoginVm);
    public Task<string?> GetRole(UserLoginVm userLoginVm);
    public Task<bool> IfEmailExists(string email);

}