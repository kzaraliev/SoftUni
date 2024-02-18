using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeminarHub.Data.Migrations
{
    public partial class UpdateError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seminars_AspNetUsers_OrginizerId",
                table: "Seminars");

            migrationBuilder.DropIndex(
                name: "IX_Seminars_OrginizerId",
                table: "Seminars");

            migrationBuilder.DropColumn(
                name: "OrginizerId",
                table: "Seminars");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Seminars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_OrganizerId",
                table: "Seminars",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seminars_AspNetUsers_OrganizerId",
                table: "Seminars",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seminars_AspNetUsers_OrganizerId",
                table: "Seminars");

            migrationBuilder.DropIndex(
                name: "IX_Seminars_OrganizerId",
                table: "Seminars");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Seminars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "OrginizerId",
                table: "Seminars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_OrginizerId",
                table: "Seminars",
                column: "OrginizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seminars_AspNetUsers_OrginizerId",
                table: "Seminars",
                column: "OrginizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
