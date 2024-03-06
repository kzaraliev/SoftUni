using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastucture.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Agent's phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Agent's phone number");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5106d4c-d6fc-416f-bee8-0f9e652786b3", "AQAAAAEAACcQAAAAEIXv9im1Qa9a6ywhvEADw5Yn+p2eT0DHL+SXLf7YbFOXflikuytztBxuPUg3D9F+Yw==", "1012d058-2d8a-44f0-87ac-3f543555e771" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68f07d0f-6afc-4551-b15b-32994c8a69e0", "AQAAAAEAACcQAAAAEJ1qNz8uqRiQ7nlCBBWKStGPN0tUJMj4f4T6QKZE4tp7Ux4gFGYE8zQRSVCxbpmlFw==", "cbb405f8-1be0-4de0-8733-3da74db980e2" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Agent's phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Agent's phone number");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14c08287-85b9-4154-a179-4dae41148652", "AQAAAAEAACcQAAAAEB4pf4H9afK2bgHfxxUv7RDOylm0YRMe+s8q18T+Vp0ynOa3qJ7hMnSEjf8rU46xhg==", "e932942e-b1e3-4ea6-9ca6-c8d7197c6fdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2929a441-bfde-44b2-b1e2-aaef116804a6", "AQAAAAEAACcQAAAAEJPlee+dAR+C8PLxqkGMnlN4KizIGz8d47gm9su6XNktDBOkkIH0cBoZOvSkorpgpw==", "0b39ad61-e365-4230-8154-6734c490c6f6" });
        }
    }
}
