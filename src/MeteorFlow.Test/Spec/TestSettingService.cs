using AutoMapper;
using MeteorFlow.Core;
using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Fx;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Fx.Services;
using MeteorFlow.Infrastructure.DateTimes;
using MeteorFlow.Test.Utils;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using SettingRepository = MeteorFlow.Test.Utils.SettingRepository;

namespace MeteorFlow.Test.Spec;

[TestFixture]
public class SettingServiceTests
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
    public async Task Add_Settings_Successfully()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        var mapper = serviceProvider.GetRequiredService<IMapper>();
        var service = serviceProvider.GetRequiredService<IServices<AppSettings, Guid>>();

        var settingToAdd = new Domain.App.AppSettings
        {
            Id = Guid.NewGuid(),
            Name = "TestKey",
            Value = "TestValue",
            Description = "TestDescription",
            Type = "TestType"
        };

        // Act
        var addedSetting = await service.AddAsync(mapper.Map<AppSettings>(settingToAdd));
        var retrievedSetting = await service.GetByIdAsync(addedSetting.Id);
        // Assert
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