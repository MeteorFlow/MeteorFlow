using System.Reflection;
using MeteorFlow.Core;
using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Core.Settings.Queries;
using MeteorFlow.Fx;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Fx.Services;
using MeteorFlow.Infrastructure.DateTimes;
using MeteorFlow.Test.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MeteorFlow.Test.Spec;

[TestFixture]
public class TestSettingQueries
{
    private TestDbContext _dbContext;
    private IServiceProvider _serviceProvider;

    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddDbContext<TestDbContext>(options =>
            options.UseInMemoryDatabase(databaseName: "TestDatabase"));

        services.AddApplicationServices();
        services.AddCoreServices();
        services.AddDateTimeProvider();
        services.AddScoped(typeof(IRepository<,>), typeof(TestRepository<,>) );
        services.AddScoped<ISettingRepository, SettingRepository>();
        services.AddScoped(typeof(IUnitOfWork), provider => provider.GetRequiredService<TestDbContext>());
        services.AddCommandHandlers(Assembly.GetExecutingAssembly()).AddQueryHandlers(Assembly.GetExecutingAssembly());

        _serviceProvider = services.BuildServiceProvider();

        _dbContext = _serviceProvider.GetRequiredService<TestDbContext>();
        SeedTestData();
    }

    private void SeedTestData(int count = 10)
    {
        var testData = GenerateTestData(count);
        _dbContext.AppSettings.AddRange(testData);
        _dbContext.SaveChanges();
    }

    private List<AppSettings> GenerateTestData(int count)
    {
        var data = new List<AppSettings>();
        for (int i = 0; i < count; i++)
        {
            var setting = new AppSettings
            {
                Id = Guid.NewGuid(),
                Name = $"RefKey_{i + 1}",
                Value = $"Value_{i + 1}",
                Description = $"Description_{i + 1}",
                Type = $"Type_{i + 1}"
            };
            data.Add(setting);
        }

        return data;
    }
    
    [Test]
    public async Task TestGetAllQueries()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        var service = serviceProvider.GetRequiredService<IServices<AppSettings, Guid>>();
        var dispatcher = serviceProvider.GetRequiredService<IQueryDispatcher>();
        
        // Act - use handler
        var expected = await service.GetAsync();
        var result = await dispatcher.Dispatch<GetAllSettings, List<AppSettings>>(new GetAllSettings());
        
        // Assert
        Assert.That(result, Has.Count.EqualTo(expected.Count));
        for (var i = 0; i < expected.Count; i++)
        {
            Assert.Multiple(() =>
            {
                Assert.That(result[i].Id, Is.EqualTo(expected[i].Id));
                Assert.That(result[i].Name, Is.EqualTo(expected[i].Name));
                Assert.That(result[i].Value, Is.EqualTo(expected[i].Value));
                Assert.That(result[i].Description, Is.EqualTo(expected[i].Description));
                Assert.That(result[i].Type, Is.EqualTo(expected[i].Type));
            });
        }
    }
}