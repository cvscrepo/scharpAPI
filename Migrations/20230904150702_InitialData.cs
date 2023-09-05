using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "Peso" },
                values: new object[,]
                {
                    { new Guid("a18f9882-1dd3-4ed7-bfed-b491aed7ba02"), null, "Actividades Personales", 50 },
                    { new Guid("a18f9882-1dd3-4ed7-bfed-b491aed7ba25"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Taks",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DateOfCompletion", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("b007a8c9-6d59-4557-9e9c-7a7082f23e1e"), new Guid("a18f9882-1dd3-4ed7-bfed-b491aed7ba25"), new DateTime(2023, 9, 4, 10, 7, 1, 947, DateTimeKind.Local).AddTicks(3342), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Pagos de servicios publicos" },
                    { new Guid("b007a8c9-6d59-4557-9e9c-7a7082f24e1e"), new Guid("a18f9882-1dd3-4ed7-bfed-b491aed7ba02"), new DateTime(2023, 9, 4, 10, 7, 1, 947, DateTimeKind.Local).AddTicks(3371), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Terminar de ver peliculas en Netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Taks",
                keyColumn: "Id",
                keyValue: new Guid("b007a8c9-6d59-4557-9e9c-7a7082f23e1e"));

            migrationBuilder.DeleteData(
                table: "Taks",
                keyColumn: "Id",
                keyValue: new Guid("b007a8c9-6d59-4557-9e9c-7a7082f24e1e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a18f9882-1dd3-4ed7-bfed-b491aed7ba02"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a18f9882-1dd3-4ed7-bfed-b491aed7ba25"));
        }
    }
}
