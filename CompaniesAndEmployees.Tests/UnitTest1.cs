using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using CompaniesAndEmployees.dotnet_api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CompaniesAndEmployees.Tests;
public class UnitTest1
{
    JsonSerializerOptions serializerOptions = new JsonSerializerOptions
    { PropertyNameCaseInsensitive = true };

    [Fact]
    public async void GetAll()
    {
        await using var app = new WebApplicationFactory<Program>();
        var client = app.CreateClient();

        var res = await client.GetAsync("/employee");
        res.EnsureSuccessStatusCode();
        var json = await res.Content.ReadAsStringAsync();
        var employees = JsonSerializer.Deserialize<List<Employee>>(json, serializerOptions);
        Assert.Equal(employees?[0].Id, 1);
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
    }
    [Fact]
    public async void AddEmployee()
    {
        await using var app = new WebApplicationFactory<Program>();
        var client = app.CreateClient();

        JsonContent content = JsonContent.Create(new Employee
        {
            FirstName = "Maarten",
            LastName = "Balliauw",
            Phone = "111111111",
            Email = "maarten@jetbrains.com"
        });
        var res = await client.PostAsync("/employee", content);

        res.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.Created, res.StatusCode);
    }
    [Fact]
    public async void SearchAndDeleteEmployee()
    {
        await using var app = new WebApplicationFactory<Program>();
        var client = app.CreateClient();
        var res1 = await client.GetAsync("/employee/search/Maarten");
        var json = await res1.Content.ReadAsStringAsync();
        var emp = JsonSerializer.Deserialize<Employee>(json, serializerOptions);
        if (emp != null)
        {
            Assert.Equal("Maarten", emp.FirstName);
            var res2 = await client.DeleteAsync("/employee/" + emp.Id);
            Assert.Equal(HttpStatusCode.OK, res2.StatusCode);
            var res3 = await client.GetAsync("/employee/" + emp.Id);
            Assert.Equal(HttpStatusCode.NotFound, res3.StatusCode);
        }
        else
        {
            Assert.Fail("Employee not found");
        }
    }
    [Fact]
    public async void Register()
    {
        await using var app = new WebApplicationFactory<Program>();
        var client = app.CreateClient();
        JsonContent content = JsonContent.Create(new UserRegistrationVm
        {
            FirstName = "Maarten",
            LastName = "Balliauw",
            Email = "maarten@jetbrains.com",
            Password = "asdasdasd"
        });
        var res2 = await client.PostAsync("/auth/register", content);
        Assert.Equal(HttpStatusCode.OK, res2.StatusCode);

    }
}