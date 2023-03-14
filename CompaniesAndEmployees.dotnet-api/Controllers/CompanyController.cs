using Microsoft.AspNetCore.Mvc;
using CompaniesAndEmployees.dotnet_api.Models;

namespace CompaniesAndEmployees.dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Company>>> Get()
        => Ok(await _companyService.GetAll());

    [HttpPost]
    public async Task<ActionResult<Company>> Create(CompanyVm companyToAdd)
    {
        Company createdCompany = await _companyService.Create(companyToAdd);
        return CreatedAtAction(nameof(Create), new { id = createdCompany.Id }, createdCompany);
    }

    [HttpDelete("{companyId:int}")]
    public async Task<ActionResult<Company>> Delete(int companyId)
    {
        Company? companyToDelete = await _companyService.GetById(companyId);
        if (companyToDelete != null)
            await _companyService.Delete(companyToDelete);
        return Ok(companyToDelete);
    }
}
