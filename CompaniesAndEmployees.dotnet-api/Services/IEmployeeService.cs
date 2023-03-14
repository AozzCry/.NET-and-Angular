using CompaniesAndEmployees.dotnet_api.Models;

public interface IEmployeeService
{
    public Task<Employee?> GetById(int id);
    public Task<Employee?> Search(string FirstName);
    public Task<List<Employee>> GetAll();
    public Task<Employee> Create(EmployeeVm employee);
    public Task<Employee> Delete(Employee employee);
}
