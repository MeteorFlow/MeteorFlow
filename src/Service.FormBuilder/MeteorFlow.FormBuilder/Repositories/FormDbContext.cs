using System.Reflection;
using MeteorFlow.FormBuilder.Entities;
using MeteorFlow.FormBuilder.Models;
using MeteorFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.FormBuilder.Repositories;


public class FormDbContext(DbContextOptions<FormDbContext> options) : DbContextUnitOfWork<FormDbContext>(options)
{
    public DbSet<FormBlocks> FormBlocks { get; set; }

    public DbSet<FormElements> FormElements { get; set; }

    public DbSet<ElementSchemas> ElementSchemas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<ElementSchemas>().HasData(
            new ElementSchemas
            {
                Id = new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460"),
                Name = "name",
                Type = "text",
                InputType = InputType.Text,
                Searchable = true,
                Required = true,
                ReadOnly = false,
                Autocomplete = false
            },
            new ElementSchemas
            {
                Id = new Guid("6ccc1efb-4054-4ace-8fdf-47346bbe6809"),
                Name = "weather_type",
                Type = "choice",
                InputType = InputType.Select,
                Searchable = true,
                Required = true,
                ReadOnly = false,
                Autocomplete = true
            }
        );
        
        builder.Entity<FormElements>().HasData(
            new FormElements
            {
                Id = new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"),
                Name = "Text input",
                Description = "Single line text input",
                Icon = "",
                Renderer = "CoreTextField",
            },
            new FormElements
            {
                Id =  new Guid("ea98ca53-bb87-485d-8aa9-750adaa9f89e"),
                Name = "Choice input",
                Description = "Plain checkout input",
                Icon = "i-mdi-checkbox-outline",
                Renderer = "CoreSelect",
            }
        );
        
        builder.Entity<FormBlocks>().HasData(
            new FormBlocks
            {
                Id = new Guid("3b732e89-af2f-4793-a234-45c9dac1f590"),
                Name = "title",
                DisplayName = "Tiêu đề",
                ElementId = new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"),
                SchemaId = new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460")
            },
            new FormBlocks
            {
                Id = new Guid("a3232fd5-64e5-464a-9ae3-fcab5d906818"),
                Name = "emergency",
                DisplayName = "Khẩn cấp",
                ElementId = new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"),
                SchemaId = new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460")
            },
            new FormBlocks
            {
                Id = new Guid("0d3007aa-d3e4-4562-8532-a3d17a95d4fc"),
                Name = "content",
                DisplayName = "Nội dung",
                ElementId = new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"),
                SchemaId = new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460")
            },
            new FormBlocks
            {
                Id = new Guid("68f49837-8a4e-4294-9df2-091068c01795"),
                Name = "notificationDate",
                DisplayName = "Ngày gửi thông báo",
                ElementId = new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"),
                SchemaId = new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460")
            }
        );

    }
}