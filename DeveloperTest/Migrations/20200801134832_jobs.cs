using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeveloperTest.Migrations
{
    public partial class jobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CustomerType",
                value: "Large");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "When",
                value: new DateTime(2020, 8, 1, 14, 48, 32, 12, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CustomerId",
                table: "Jobs",
                column: "CustomerId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Jobs_Customers_CustomerId",
            //    table: "Jobs",
            //    column: "CustomerId",
            //    principalTable: "Customers",
            //    principalColumn: "CustomerId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CustomerId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Jobs");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CustomerType",
                value: "large");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "When",
                value: new DateTime(2020, 8, 1, 12, 15, 42, 207, DateTimeKind.Local).AddTicks(8338));
        }
    }
}
