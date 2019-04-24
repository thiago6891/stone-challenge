using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.RegistrationNumber);

            builder.Property(e => e.RegistrationNumber)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Property(e => e.Name)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Property(e => e.Sector)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Property(e => e.JobTitle)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Property(e => e.GrossSalary)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired()
                .HasColumnType("Money");

            builder.Property(e => e.AdmissionDate)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Property(e => e.IsIntern)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Ignore(e => e.Bonus);
        }
    }
}