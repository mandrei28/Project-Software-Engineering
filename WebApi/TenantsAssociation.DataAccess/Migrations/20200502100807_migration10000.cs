using Microsoft.EntityFrameworkCore.Migrations;

namespace TenantsAssociation.DataAccess.Migrations
{
    public partial class migration10000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Administrators",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Administrators",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Administrators");
        }
    }
}
