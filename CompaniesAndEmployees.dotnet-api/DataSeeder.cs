using CompaniesAndEmployees.dotnet_api.Models;

public class DataSeeder
{
    private readonly DataContext _context;

    public DataSeeder(DataContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (!_context.Employees.Any())
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    FirstName = "Emil",
                    LastName ="Knysak",
                    Email = "ek@ek.ek",
                    Phone = "123123123",
                    CreatedDate = new DateTime()
                },
                new Employee()
                {
                    Id = 2,
                    FirstName = "Jan",
                    LastName ="Dmowski",
                    Email = "ja@nek.ja",
                    Phone = "321321321",
                    CreatedDate = new DateTime()
                },
            };
            _context.Employees.AddRange(employees);

            var companies = new List<Company>()
            {
                new Company()
                {
                    Id = 1,
                    Name = "Microsoft",
                    CreatedDate = new DateTime()
                },
                new Company()
                {
                    Id = 2,
                    Name = "Appple",
                    CreatedDate = new DateTime()
                },
            };
            _context.Companies.AddRange(companies);

            _context.SaveChanges();
        }
    }
}