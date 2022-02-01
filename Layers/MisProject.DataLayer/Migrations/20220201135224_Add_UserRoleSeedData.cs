using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MisProject.DataLayer.Migrations
{
    public partial class Add_UserRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 3, 2, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 3);
        }
    }
}
