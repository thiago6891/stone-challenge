using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class SeedEmployeeDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "RegistrationNumber", "AdmissionDate", "GrossSalary", "IsIntern", "JobTitle", "Name", "Sector" },
                values: new object[,]
                {
                    { 9968, new DateTime(2012, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12696.20m, false, "Diretor Financeiro", "Victor Wilson", 0 },
                    { 2949, new DateTime(2014, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5694.14m, false, "Analista de Finanças", "Stephenson Stone", 2 },
                    { 7676, new DateTime(2018, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1591.69m, false, "Copeiro", "Maricela Martin", 4 },
                    { 6335, new DateTime(2014, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1019.88m, false, "Jovem Aprendiz", "Beulah Long", 3 },
                    { 14319, new DateTime(2016, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 18053.25m, false, "Diretor Tecnologia", "Abraham Jones", 0 },
                    { 538, new DateTime(2014, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2330.19m, false, "Auxiliar Administrativo", "Ashlee Wood", 1 },
                    { 4237, new DateTime(2014, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2266.46m, false, "Atendente", "Hess Sloan", 5 },
                    { 7361, new DateTime(2016, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2166.25m, false, "Auxiliar Administrativo", "Avila Kane", 1 },
                    { 273, new DateTime(2016, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1426.13m, true, "Estagiário", "Petersen Coleman", 2 },
                    { 2105, new DateTime(2015, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1491.45m, true, "Estagiário", "Dorthy Lee", 2 },
                    { 7293, new DateTime(2017, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4457.08m, false, "Economista Pleno", "Morton Battle", 1 },
                    { 5961, new DateTime(2016, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2671.26m, false, "Contador Júnior", "Jillian Odonnell", 1 },
                    { 6806, new DateTime(2014, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2571.73m, false, "Auxiliar Administrativo", "Ella Hale", 0 },
                    { 7961, new DateTime(2015, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2101.68m, false, "Auxiliar de Contabilidade", "Francesca Hewitt", 1 },
                    { 1843, new DateTime(2016, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2120.08m, false, "Atendente de Almoxarifado", "Daugherty Kramer", 4 },
                    { 4867, new DateTime(2015, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2768.28m, false, "Auxiliar Administrativo", "Danielle Blanchard", 0 },
                    { 5253, new DateTime(2016, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2215.04m, false, "Economista Júnior", "Wong Austin", 2 },
                    { 7463, new DateTime(2018, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3199.82m, false, "Contador Pleno", "Charlotte Romero", 2 },
                    { 8174, new DateTime(2015, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3899.74m, false, "Líder de Relacionamento", "Sherman Hodges", 5 },
                    { 4468, new DateTime(2015, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1396.52m, false, "Auxiliar de Contabilidade", "Flossie Wilson", 1 },
                    { 8601, new DateTime(2017, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1800.16m, false, "Auxiliar de Ouvidoria", "Taylor Mccarthy", 5 },
                    { 6877, new DateTime(2016, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3371.47m, false, "Líder de Ouvidoria", "Cross Perkins", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 1843);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 2105);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 2949);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 4237);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 4468);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 4867);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 5253);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 5961);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 6335);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 6806);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 6877);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 7293);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 7361);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 7463);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 7676);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 7961);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 8174);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 8601);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 9968);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "RegistrationNumber",
                keyValue: 14319);
        }
    }
}
