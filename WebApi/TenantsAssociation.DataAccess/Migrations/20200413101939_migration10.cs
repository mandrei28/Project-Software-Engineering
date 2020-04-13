using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TenantsAssociation.DataAccess.Migrations
{
    public partial class migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorId",
                table: "Building",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Building_AdministratorId",
                table: "Building",
                column: "AdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Administrators_AdministratorId",
                table: "Building",
                column: "AdministratorId",
                principalTable: "Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Administrators_AdministratorId",
                table: "Building");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropIndex(
                name: "IX_Building_AdministratorId",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Building");

            migrationBuilder.AddColumn<Guid>(
                name: "UserTypeId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
