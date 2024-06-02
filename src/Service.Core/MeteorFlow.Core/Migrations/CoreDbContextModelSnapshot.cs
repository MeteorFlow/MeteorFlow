﻿// <auto-generated />
using System;
using MeteorFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeteorFlow.Core.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MeteorFlow.Core.Entities.AppDefinitions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("BaseDefinitionId")
                        .HasColumnType("uuid")
                        .HasColumnName("base_definition_id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("DefinitionType")
                        .HasColumnType("integer")
                        .HasColumnName("definition_type");

                    b.Property<DateTimeOffset?>("DeleteDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(32767)
                        .HasColumnType("character varying(32767)")
                        .HasColumnName("description");

                    b.Property<string>("Icon")
                        .HasMaxLength(2147483647)
                        .HasColumnType("text")
                        .HasColumnName("icon");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<byte[]>("RowVersion")
                        .HasColumnType("bytea")
                        .HasColumnName("row_version");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.HasKey("Id")
                        .HasName("pk_app_definitions");

                    b.HasIndex("BaseDefinitionId")
                        .HasDatabaseName("ix_app_definitions_base_definition_id");

                    b.ToTable("app_definitions", (string)null);
                });

            modelBuilder.Entity("MeteorFlow.Core.Entities.AppInstances", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTimeOffset?>("DeleteDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(32767)
                        .HasColumnType("character varying(32767)")
                        .HasColumnName("description");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text")
                        .HasColumnName("icon");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<byte[]>("RowVersion")
                        .HasColumnType("bytea")
                        .HasColumnName("row_version");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid")
                        .HasColumnName("version_id");

                    b.HasKey("Id")
                        .HasName("pk_app_instances");

                    b.HasIndex("VersionId")
                        .HasDatabaseName("ix_app_instances_version_id");

                    b.ToTable("app_instances", (string)null);
                });

            modelBuilder.Entity("MeteorFlow.Core.Entities.AppSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTimeOffset?>("DeleteDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(32767)
                        .HasColumnType("character varying(32767)")
                        .HasColumnName("description");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<byte[]>("RowVersion")
                        .HasColumnType("bytea")
                        .HasColumnName("row_version");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("type");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_app_settings");

                    b.ToTable("app_settings", (string)null);
                });

            modelBuilder.Entity("MeteorFlow.Core.Entities.AppVersionControls", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AppDefinitionId")
                        .HasColumnType("uuid")
                        .HasColumnName("app_definition_id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTimeOffset?>("DeleteDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_date");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<int>("MajorVersion")
                        .HasColumnType("integer")
                        .HasColumnName("major_version");

                    b.Property<int>("MinorVersion")
                        .HasColumnType("integer")
                        .HasColumnName("minor_version");

                    b.Property<int>("PatchVersion")
                        .HasColumnType("integer")
                        .HasColumnName("patch_version");

                    b.Property<byte[]>("RowVersion")
                        .HasColumnType("bytea")
                        .HasColumnName("row_version");

                    b.HasKey("Id")
                        .HasName("pk_app_version_controls");

                    b.HasIndex("AppDefinitionId")
                        .HasDatabaseName("ix_app_version_controls_app_definition_id");

                    b.ToTable("app_version_controls", (string)null);
                });

            modelBuilder.Entity("MeteorFlow.Core.Entities.AppDefinitions", b =>
                {
                    b.HasOne("MeteorFlow.Core.Entities.AppDefinitions", "BaseDefinition")
                        .WithMany("SubDefinitions")
                        .HasForeignKey("BaseDefinitionId")
                        .HasConstraintName("fk_app_definitions_app_definitions_base_definition_id");

                    b.Navigation("BaseDefinition");
                });

            modelBuilder.Entity("MeteorFlow.Core.Entities.AppInstances", b =>
                {
                    b.HasOne("MeteorFlow.Core.Entities.AppVersionControls", "AppliedVersion")
                        .WithMany("AppInstances")
                        .HasForeignKey("VersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_instances_app_version_controls_version_id");

                    b.Navigation("AppliedVersion");
                });

            modelBuilder.Entity("MeteorFlow.Core.Entities.AppVersionControls", b =>
                {
                    b.HasOne("MeteorFlow.Core.Entities.AppDefinitions", "AppDefinition")
                        .WithMany("AppVersionControls")
                        .HasForeignKey("AppDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_version_controls_app_definitions_app_definition_id");

                    b.Navigation("AppDefinition");
                });

            modelBuilder.Entity("MeteorFlow.Core.Entities.AppDefinitions", b =>
                {
                    b.Navigation("AppVersionControls");

                    b.Navigation("SubDefinitions");
                });

            modelBuilder.Entity("MeteorFlow.Core.Entities.AppVersionControls", b =>
                {
                    b.Navigation("AppInstances");
                });
#pragma warning restore 612, 618
        }
    }
}
