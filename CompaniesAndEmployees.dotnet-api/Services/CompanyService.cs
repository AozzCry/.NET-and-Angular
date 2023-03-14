using Microsoft.EntityFrameworkCore;
using CompaniesAndEmployees.dotnet_api.Models;
using AutoMapper;

public class CompanyService : ICompanyService
{
    private readonly ILogger<CompanyService> _logger;
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CompanyService(ILogger<CompanyService> logger, IMapper mapper, DataContext context)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }

    public async Task<Company?> GetById(int companyId)
    {
        try
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetById Companie");
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<Company>> GetAll()
    {
        try
        {
            return await _context.Companies.Include(c => c.Address).Include(c => c.Employees).ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetAll Companies");
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<Company> Create(CompanyVm companyVm)
    {
        try
        {
            var company = _mapper.Map<Company>(companyVm);
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();

            return company;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Create Company");
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<Company> Delete(Company company)
    {
        try
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return company;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Delete Company");
            throw new Exception(ex.Message, ex);
        }
    }
}
