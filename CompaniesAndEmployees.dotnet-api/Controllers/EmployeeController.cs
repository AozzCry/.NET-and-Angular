using Microsoft.AspNetCore.Mvc;
using CompaniesAndEmployees.dotnet_api.Models;

namespace CompaniesAndEmployees.dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("search/{FirstName}")]
    public async Task<ActionResult<Employee>> Search(string FirstName)
    {
        Employee? employee = await _employeeService.Search(FirstName);
        if (employee != null) return Ok(employee);
        else return NotFound();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Employee>> GetById(int Id)
    {
        Employee? employee = await _employeeService.GetById(Id);
        if (employee != null) return Ok(employee);
        else return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<List<Employee>>> Get()
        => Ok(await _employeeService.GetAll());

    [HttpPost]
    public async Task<ActionResult<Employee>> Create(EmployeeVm employeeToAdd)
    {
        Employee createdEmployee = await _employeeService.Create(employeeToAdd);
        return CreatedAtAction(nameof(Create), new { id = createdEmployee.Id }, createdEmployee);
    }

    [HttpDelete("{employeeId:int}")]
    public async Task<ActionResult<Employee>> Delete(int employeeId)
    {
        Employee? employeeToDelete = await _employeeService.GetById(employeeId);
        if (employeeToDelete != null)
            await _employeeService.Delete(employeeToDelete);
        return Ok(employeeToDelete);
    }
}
