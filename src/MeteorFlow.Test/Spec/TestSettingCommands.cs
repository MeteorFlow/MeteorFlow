using System.Reflection;
using AutoMapper;
using MeteorFlow.Core;
using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Core.Settings.Commands;
using MeteorFlow.Core.Settings.Queries;
using MeteorFlow.Fx;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Fx.Services;
using MeteorFlow.Infrastructure.DateTimes;
using MeteorFlow.Test.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MeteorFlow.Test.Spec;

[TestFixture]
public class TestSettingCommands
{
    private TestDbContext _dbContext;
    private IServiceProvider _serviceProvider;

    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddDbContext<TestDbContext>(options =>
            options.UseInMemoryDatabase(databaseName: "TestDatabase")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            );

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

        var mapper = serviceProvider.GetRequiredService<IMapper>();

        var service = serviceProvider.GetRequiredService<IServices<AppSettings, Guid>>();
        var dispatcher = serviceProvider.GetRequiredService<ICommandDispatcher>();
        var settingToAdd = new Domain.App.AppSettings
        {
            Name = "TestKey",
            Value = "TestValue",
            Description = "TestDescription",
            Type = "TestType"
        };
        // Act - use handler
        var retrievedSetting = await dispatcher.Dispatch<AddUpdateSettingCommand, AppSettings>(new AddUpdateSettingCommand(mapper.Map<AppSettings>(settingToAdd)));
        Assert.Multiple(() =>
        {
            Assert.That(retrievedSetting, Is.Not.Null);
            Assert.That(_dbContext.AppSettings.Count(), Is.EqualTo(11));
            Assert.That(settingToAdd.Name, Is.EqualTo(retrievedSetting.Name));
            Assert.That(settingToAdd.Value, Is.EqualTo(retrievedSetting.Value));
            Assert.That(settingToAdd.Description, Is.EqualTo(retrievedSetting.Description));
            Assert.That(settingToAdd.Type, Is.EqualTo(retrievedSetting.Type));
        });
    }
}