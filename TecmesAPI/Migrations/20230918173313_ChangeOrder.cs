using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderProducts",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "OrderProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "OrderProducts");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "OrderProducts",
                newName: "OrderId");
        }
    }
}
