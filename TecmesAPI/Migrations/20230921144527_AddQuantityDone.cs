using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityDone",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityDone",
                table: "OrderProducts");
        }
    }
}
