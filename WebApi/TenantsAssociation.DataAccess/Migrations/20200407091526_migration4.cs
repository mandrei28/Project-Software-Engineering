using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TenantsAssociation.DataAccess.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                table: "Polls",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Polls_BuildingId",
                table: "Polls",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polls_Building_BuildingId",
                table: "Polls",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polls_Building_BuildingId",
                table: "Polls");

            migrationBuilder.DropIndex(
                name: "IX_Polls_BuildingId",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Polls");
        }
    }
}
