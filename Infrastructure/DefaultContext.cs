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
        }
    }
}