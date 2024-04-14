using AutoMapper;
using MeteorFlow.Core;
using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Fx;
using MeteorFlow.Fx.DateTimes;
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
        services.AddApplicationHandlers();

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

        var dateTimeProvider = serviceProvider.GetRequiredService<IDateTimeProvider>();
        var mapper = serviceProvider.GetRequiredService<IMapper>();
        var repository = serviceProvider.GetRequiredService<ISettingRepository>();
        var service = serviceProvider.GetRequiredService<IServices<AppSettings, Guid>>();
        var dispatcher = serviceProvider.GetRequiredService<IQueryDispatcher>();
        
        // Act - use handler
        var expected = await service.GetAsync();
        var result = await dispatcher.Dispatch(new GetAllQuery<AppSettings, Guid>());
        
        // Assert
        Assert.AreEqual(expected.Count, result.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.AreEqual(expected[i].Id, result[i].Id);
            Assert.AreEqual(expected[i].Name, result[i].Name);
            Assert.AreEqual(expected[i].Value, result[i].Value);
            Assert.AreEqual(expected[i].Description, result[i].Description);
            Assert.AreEqual(expected[i].Type, result[i].Type);
        }
    }
}