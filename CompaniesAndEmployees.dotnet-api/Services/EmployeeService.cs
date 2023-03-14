using Microsoft.EntityFrameworkCore;
using CompaniesAndEmployees.dotnet_api.Models;
using AutoMapper;

public class EmployeeService : IEmployeeService
{
    private readonly ILogger<EmployeeService> _logger;
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public EmployeeService(ILogger<EmployeeService> logger, IMapper mapper, DataContext context)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }

    public async Task<Employee?> GetById(int employeeId)
    {
        try
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetById Employee");
            throw new Exception(ex.Message, ex);
        }
    }
    public async Task<Employee?> Search(string FirstName)
    {
        try
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.FirstName == FirstName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetById Employee");
            throw new Exception(ex.Message, ex);
        }
    }
    public Task<List<Employee>> GetAll()
    {
        try
        {
            var employees = _context.Employees.Include(e => e.Address).ToListAsync();

            if (employees == null)
                throw new ArgumentNullException(nameof(employees));

            return employees;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetAll Employees");
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<Employee> Create(EmployeeVm employeeVm)
    {
        try
        {
            var employee = _mapper.Map<Employee>(employeeVm);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Create Employee");
            throw new Exception(ex.Message, ex);
        }
    }


    public async Task<Employee> Delete(Employee employee)
    {
        try
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Delete Empployee");
            throw new Exception(ex.Message, ex);
        }
    }
}
