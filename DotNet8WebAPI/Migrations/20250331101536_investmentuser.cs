using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class investmentuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Advisors",
                keyColumn: "Id",
                keyValue: 1,
                column: "FirstName",
                value: "Geeta");

            migrationBuilder.InsertData(
                table: "InvestmentUser",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "Password", "Username" },
                values: new object[] { 1, "System", false, "", "System", "System" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentUser");

            migrationBuilder.UpdateData(
                table: "Advisors",
                keyColumn: "Id",
                keyValue: 1,
                column: "FirstName",
                value: "Shubhang");
        }
    }
}
