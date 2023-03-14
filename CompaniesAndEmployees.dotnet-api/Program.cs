using Microsoft.EntityFrameworkCore;
using AutoMapper;

using CompaniesAndEmployees.dotnet_api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MainProfile));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
     {
         c.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
         c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
         {
             ValidAudience = builder.Configuration["Auth0:Audience"],
             ValidIssuer = $"{builder.Configuration["Auth0:Domain"]}"
         };
     });
builder.Services.AddAuthorization();
builder.Services.AddAuthorizationBuilder()
  .AddPolicy("todo:read-write", p => p.
            RequireAuthenticatedUser().
            RequireClaim("scope", "todo:read-write"));

builder.Services.AddCors();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), builder =>
        { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); }
    ));


builder.Services.AddControllers();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
    options.WithOrigins("http://localhost:3000", "http://localhost:4200")
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .AllowAnyHeader()
);

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<Company, CompanyVm>();
        CreateMap<CompanyVm, Company>();

        CreateMap<Employee, EmployeeVm>();
        CreateMap<EmployeeVm, Employee>();

        CreateMap<UserRegistrationVm, User>();
        CreateMap<User, UserRegistrationVm>();

    }
}

public partial class Program { }