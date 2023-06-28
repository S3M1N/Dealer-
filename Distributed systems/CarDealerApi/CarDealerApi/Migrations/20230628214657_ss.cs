using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerApi.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Role",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
