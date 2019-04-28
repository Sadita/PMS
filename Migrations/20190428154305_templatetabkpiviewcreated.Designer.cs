﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMS.Models.Domain;

namespace PMS.Migrations
{
    [DbContext(typeof(PMSDBContext))]
    [Migration("20190428154305_templatetabkpiviewcreated")]
    partial class templatetabkpiviewcreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PMS.Models.Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Rank");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PMS.Models.Domain.Kpi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Kpis");
                });

            modelBuilder.Entity("PMS.Models.Domain.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KpiId");

                    b.Property<string>("Name");

                    b.Property<int>("Rank");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("KpiId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("PMS.Models.Domain.Tab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Title");

                    b.HasKey("Id");

                    b.ToTable("Tabs");
                });

            modelBuilder.Entity("PMS.Models.Domain.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("PMS.Models.Domain.TemplateTab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TabId");

                    b.Property<int>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("TabId");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateTabs");
                });

            modelBuilder.Entity("PMS.Models.Domain.TemplateTabKpi", b =>
                {
                    b.Property<int>("TemplateTabId");

                    b.Property<int>("KpiId");

                    b.HasKey("TemplateTabId", "KpiId");

                    b.HasIndex("KpiId");

                    b.ToTable("TemplateTabKpis");
                });

            modelBuilder.Entity("PMS.Models.Domain.Level", b =>
                {
                    b.HasOne("PMS.Models.Domain.Kpi", "Kpi")
                        .WithMany("Levels")
                        .HasForeignKey("KpiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMS.Models.Domain.TemplateTab", b =>
                {
                    b.HasOne("PMS.Models.Domain.Tab", "Tab")
                        .WithMany("TemplateTabs")
                        .HasForeignKey("TabId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMS.Models.Domain.Template", "Template")
                        .WithMany("TemplateTabs")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMS.Models.Domain.TemplateTabKpi", b =>
                {
                    b.HasOne("PMS.Models.Domain.Kpi", "Kpi")
                        .WithMany("TemplateTabKpis")
                        .HasForeignKey("KpiId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMS.Models.Domain.TemplateTab", "TemplateTab")
                        .WithMany("TemplateTabKpis")
                        .HasForeignKey("TemplateTabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
