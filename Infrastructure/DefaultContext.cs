using ApplicationCore.Enumerations;
using ApplicationCore.Models;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeEntityConfiguration());

            builder.Entity<Employee>().HasData(
                new Employee(9968, "Victor Wilson", Sector.Directors, "Diretor Financeiro", 12696.20M, new DateTime(2012, 1, 5), false),
                new Employee(4468, "Flossie Wilson", Sector.Accounting, "Auxiliar de Contabilidade", 1396.52M, new DateTime(2015, 1, 5), false),
                new Employee(8174, "Sherman Hodges", Sector.CustomerRelationship, "Líder de Relacionamento", 3899.74M, new DateTime(2015, 6, 7), false),
                new Employee(7463, "Charlotte Romero", Sector.Financial, "Contador Pleno", 3199.82M, new DateTime(2018, 1, 3), false),
                new Employee(5253, "Wong Austin", Sector.Financial, "Economista Júnior", 2215.04M, new DateTime(2016, 8, 7), false),
                new Employee(4867, "Danielle Blanchard", Sector.Directors, "Auxiliar Administrativo", 2768.28M, new DateTime(2015, 10, 17), false),
                new Employee(1843, "Daugherty Kramer", Sector.GeneralServices, "Atendente de Almoxarifado", 2120.08M, new DateTime(2016, 4, 21), false),
                new Employee(7961, "Francesca Hewitt", Sector.Accounting, "Auxiliar de Contabilidade", 2101.68M, new DateTime(2015, 6, 21), false),
                new Employee(6806, "Ella Hale", Sector.Directors, "Auxiliar Administrativo", 2571.73M, new DateTime(2014, 7, 27), false),
                new Employee(5961, "Jillian Odonnell", Sector.Accounting, "Contador Júnior", 2671.26M, new DateTime(2016, 9, 8), false),
                new Employee(7293, "Morton Battle", Sector.Accounting, "Economista Pleno", 4457.08M, new DateTime(2017, 10, 19), false),
                new Employee(2105, "Dorthy Lee", Sector.Financial, "Estagiário", 1491.45M, new DateTime(2015, 3, 16), true),
                new Employee(273, "Petersen Coleman", Sector.Financial, "Estagiário", 1426.13M, new DateTime(2016, 9, 20), true),
                new Employee(7361, "Avila Kane", Sector.Accounting, "Auxiliar Administrativo", 2166.25M, new DateTime(2016, 9, 16), false),
                new Employee(4237, "Hess Sloan", Sector.CustomerRelationship, "Atendente", 2266.46M, new DateTime(2014, 10, 27), false),
                new Employee(538, "Ashlee Wood", Sector.Accounting, "Auxiliar Administrativo", 2330.19M, new DateTime(2014, 7, 15), false),
                new Employee(14319, "Abraham Jones", Sector.Directors, "Diretor Tecnologia", 18053.25M, new DateTime(2016, 7, 5), false),
                new Employee(6335, "Beulah Long", Sector.Technology, "Jovem Aprendiz", 1019.88M, new DateTime(2014, 8, 27), false),
                new Employee(7676, "Maricela Martin", Sector.GeneralServices, "Copeiro", 1591.69M, new DateTime(2018, 1, 17), false),
                new Employee(2949, "Stephenson Stone", Sector.Financial, "Analista de Finanças", 5694.14M, new DateTime(2014, 1, 26), false),
                new Employee(8601, "Taylor Mccarthy", Sector.CustomerRelationship, "Auxiliar de Ouvidoria", 1800.16M, new DateTime(2017, 3, 31), false),
                new Employee(6877, "Cross Perkins", Sector.CustomerRelationship, "Líder de Ouvidoria", 3371.47M, new DateTime(2016, 12, 6), false));
        }
    }
}