using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taks_Category_CategoryId",
                table: "Taks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Taks",
                table: "Taks");

            migrationBuilder.RenameTable(
                name: "Taks",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_Taks_CategoryId",
                table: "Task",
                newName: "IX_Task_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("b007a8c9-6d59-4557-9e9c-7a7082f23e1e"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 4, 10, 12, 15, 544, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("b007a8c9-6d59-4557-9e9c-7a7082f24e1e"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 4, 10, 12, 15, 544, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Category_CategoryId",
                table: "Task",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Category_CategoryId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Taks");

            migrationBuilder.RenameIndex(
                name: "IX_Task_CategoryId",
                table: "Taks",
                newName: "IX_Taks_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Taks",
                table: "Taks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Taks",
                keyColumn: "Id",
                keyValue: new Guid("b007a8c9-6d59-4557-9e9c-7a7082f23e1e"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 4, 10, 7, 1, 947, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.UpdateData(
                table: "Taks",
                keyColumn: "Id",
                keyValue: new Guid("b007a8c9-6d59-4557-9e9c-7a7082f24e1e"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 4, 10, 7, 1, 947, DateTimeKind.Local).AddTicks(3371));

            migrationBuilder.AddForeignKey(
                name: "FK_Taks_Category_CategoryId",
                table: "Taks",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
