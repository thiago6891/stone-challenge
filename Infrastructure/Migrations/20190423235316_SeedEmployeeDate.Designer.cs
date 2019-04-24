﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20190423235316_SeedEmployeeDate")]
    partial class SeedEmployeeDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Models.Employee", b =>
                {
                    b.Property<int>("RegistrationNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<decimal>("GrossSalary")
                        .HasColumnType("Money");

                    b.Property<bool>("IsIntern");

                    b.Property<string>("JobTitle")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Sector");

                    b.HasKey("RegistrationNumber");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            RegistrationNumber = 9968,
                            AdmissionDate = new DateTime(2012, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 12696.20m,
                            IsIntern = false,
                            JobTitle = "Diretor Financeiro",
                            Name = "Victor Wilson",
                            Sector = 0
                        },
                        new
                        {
                            RegistrationNumber = 4468,
                            AdmissionDate = new DateTime(2015, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 1396.52m,
                            IsIntern = false,
                            JobTitle = "Auxiliar de Contabilidade",
                            Name = "Flossie Wilson",
                            Sector = 1
                        },
                        new
                        {
                            RegistrationNumber = 8174,
                            AdmissionDate = new DateTime(2015, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 3899.74m,
                            IsIntern = false,
                            JobTitle = "Líder de Relacionamento",
                            Name = "Sherman Hodges",
                            Sector = 5
                        },
                        new
                        {
                            RegistrationNumber = 7463,
                            AdmissionDate = new DateTime(2018, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 3199.82m,
                            IsIntern = false,
                            JobTitle = "Contador Pleno",
                            Name = "Charlotte Romero",
                            Sector = 2
                        },
                        new
                        {
                            RegistrationNumber = 5253,
                            AdmissionDate = new DateTime(2016, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 2215.04m,
                            IsIntern = false,
                            JobTitle = "Economista Júnior",
                            Name = "Wong Austin",
                            Sector = 2
                        },
                        new
                        {
                            RegistrationNumber = 4867,
                            AdmissionDate = new DateTime(2015, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 2768.28m,
                            IsIntern = false,
                            JobTitle = "Auxiliar Administrativo",
                            Name = "Danielle Blanchard",
                            Sector = 0
                        },
                        new
                        {
                            RegistrationNumber = 1843,
                            AdmissionDate = new DateTime(2016, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 2120.08m,
                            IsIntern = false,
                            JobTitle = "Atendente de Almoxarifado",
                            Name = "Daugherty Kramer",
                            Sector = 4
                        },
                        new
                        {
                            RegistrationNumber = 7961,
                            AdmissionDate = new DateTime(2015, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 2101.68m,
                            IsIntern = false,
                            JobTitle = "Auxiliar de Contabilidade",
                            Name = "Francesca Hewitt",
                            Sector = 1
                        },
                        new
                        {
                            RegistrationNumber = 6806,
                            AdmissionDate = new DateTime(2014, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 2571.73m,
                            IsIntern = false,
                            JobTitle = "Auxiliar Administrativo",
                            Name = "Ella Hale",
                            Sector = 0
                        },
                        new
                        {
                            RegistrationNumber = 5961,
                            AdmissionDate = new DateTime(2016, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 2671.26m,
                            IsIntern = false,
                            JobTitle = "Contador Júnior",
                            Name = "Jillian Odonnell",
                            Sector = 1
                        },
                        new
                        {
                            RegistrationNumber = 7293,
                            AdmissionDate = new DateTime(2017, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 4457.08m,
                            IsIntern = false,
                            JobTitle = "Economista Pleno",
                            Name = "Morton Battle",
                            Sector = 1
                        },
                        new
                        {
                            RegistrationNumber = 2105,
                            AdmissionDate = new DateTime(2015, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 1491.45m,
                            IsIntern = true,
                            JobTitle = "Estagiário",
                            Name = "Dorthy Lee",
                            Sector = 2
                        },
                        new
                        {
                            RegistrationNumber = 273,
                            AdmissionDate = new DateTime(2016, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 1426.13m,
                            IsIntern = true,
                            JobTitle = "Estagiário",
                            Name = "Petersen Coleman",
                            Sector = 2
                        },
                        new
                        {
                            RegistrationNumber = 7361,
                            AdmissionDate = new DateTime(2016, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 2166.25m,
                            IsIntern = false,
                            JobTitle = "Auxiliar Administrativo",
                            Name = "Avila Kane",
                            Sector = 1
                        },
                        new
                        {
                            RegistrationNumber = 4237,
                            AdmissionDate = new DateTime(2014, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 2266.46m,
                            IsIntern = false,
                            JobTitle = "Atendente",
                            Name = "Hess Sloan",
                            Sector = 5
                        },
                        new
                        {
                            RegistrationNumber = 538,
                            AdmissionDate = new DateTime(2014, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 2330.19m,
                            IsIntern = false,
                            JobTitle = "Auxiliar Administrativo",
                            Name = "Ashlee Wood",
                            Sector = 1
                        },
                        new
                        {
                            RegistrationNumber = 14319,
                            AdmissionDate = new DateTime(2016, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 18053.25m,
                            IsIntern = false,
                            JobTitle = "Diretor Tecnologia",
                            Name = "Abraham Jones",
                            Sector = 0
                        },
                        new
                        {
                            RegistrationNumber = 6335,
                            AdmissionDate = new DateTime(2014, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 1019.88m,
                            IsIntern = false,
                            JobTitle = "Jovem Aprendiz",
                            Name = "Beulah Long",
                            Sector = 3
                        },
                        new
                        {
                            RegistrationNumber = 7676,
                            AdmissionDate = new DateTime(2018, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 1591.69m,
                            IsIntern = false,
                            JobTitle = "Copeiro",
                            Name = "Maricela Martin",
                            Sector = 4
                        },
                        new
                        {
                            RegistrationNumber = 2949,
                            AdmissionDate = new DateTime(2014, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 5694.14m,
                            IsIntern = false,
                            JobTitle = "Analista de Finanças",
                            Name = "Stephenson Stone",
                            Sector = 2
                        },
                        new
                        {
                            RegistrationNumber = 8601,
                            AdmissionDate = new DateTime(2017, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 1800.16m,
                            IsIntern = false,
                            JobTitle = "Auxiliar de Ouvidoria",
                            Name = "Taylor Mccarthy",
                            Sector = 5
                        },
                        new
                        {
                            RegistrationNumber = 6877,
                            AdmissionDate = new DateTime(2016, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrossSalary = 3371.47m,
                            IsIntern = false,
                            JobTitle = "Líder de Ouvidoria",
                            Name = "Cross Perkins",
                            Sector = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
