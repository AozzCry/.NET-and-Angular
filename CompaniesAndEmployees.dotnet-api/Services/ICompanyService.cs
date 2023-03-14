using CompaniesAndEmployees.dotnet_api.Models;

public interface ICompanyService
{
    public Task<Company?> GetById(int companyId);
    public Task<List<Company>> GetAll();
    public Task<Company> Create(CompanyVm companyVm);
    public Task<Company> Delete(Company company);

}
