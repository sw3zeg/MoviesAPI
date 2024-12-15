using System.Net;
using System.Text;
using System.Text.Json;
using System.Transactions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Testing.Platform.Services;
using Movies.Application.Common.Commands.Movies;
using Movies.Persistence.Migrations;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Movies.API.IntegrationTests;


[TestFixture]
public class GenresControllerTests
{

    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;
    
    
    [OneTimeSetUp]
    public void SetUp()
    {
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Test");
        });
        
        _client = _factory.CreateClient();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }
    
    
    [Test]
    public async Task CreateOne_WithoutBody_BadRequest()
    {
        // Act
        
        var response = await _client.PostAsync("/api/genres", null);
        
        // Assert
        
        Assert.IsTrue(IsXError(response.StatusCode, 400));
    }
    
    [Test]
    public async Task CreateOne_InvalidBody_BadRequest()
    {
        // Act

        var body = new
        {
            test = "123"
        };
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("/api/genres", content);
        
        // Assert
        
        Assert.IsTrue(IsXError(response.StatusCode, 400));
    }

    [Test]
    public async Task CreateOne_ValidBody_Ok()
    {
        // Act

        var body = new
        {
            Title = "test 1"
        };
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("/api/genres", content);
        
        // Assert
        
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
    
    
    
    [Test]
    public async Task Query_ValidBody_Ok()
    {
        // Act

        var queryParams = new Dictionary<String, String>
        {
            { "query", "приключенческие" },
            { "limit", "2" },
            { "offset", "1" }
        };
        var queryString = string.Join("&", queryParams.Select(kv => $"{kv.Key}={kv.Value}"));
        var url = $"http://localhost:5048/api/genres?{queryString}";
        
        var response = await _client.GetAsync(url);
        
        // Assert
        
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
    
    
    
    private Boolean IsXError(HttpStatusCode code, Int32 xx)
    {
        return (Int32)code >= xx && (Int32)code <= xx + 100;
    }
}