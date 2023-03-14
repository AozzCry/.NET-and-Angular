using Microsoft.EntityFrameworkCore;

namespace CompaniesAndEmployees.dotnet_api.Models;

public class DataContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee()
            {
                Id = 1,
                FirstName = "Emil",
                LastName = "Knysak",
                Email = "ek@ek.ek",
                Phone = "123123123",
                CreatedDate = new DateTime()
            },
            new Employee()
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Jon",
                Email = "ja@sd.fd",
                Phone = "3213213211",
                CreatedDate = new DateTime()
            }
        );

        modelBuilder.Entity<Company>().HasData(
           new Company()
           {
               Id = 1,
               Name = "Microsoft",
               CreatedDate = new DateTime()
           },
           new Company()
           {
               Id = 2,
               Name = "Apple",
               CreatedDate = new DateTime()
           }
        );
    }
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }
}