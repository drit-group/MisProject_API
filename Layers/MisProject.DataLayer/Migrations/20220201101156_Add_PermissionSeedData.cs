using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MisProject.DataLayer.Migrations
{
    public partial class Add_PermissionSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "ParentPermissionId", "PermissionTitle" },
                values: new object[] { 1, null, "پنل مدیریت" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "ParentPermissionId", "PermissionTitle" },
                values: new object[] { 2, null, "مدیریت کاربران" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "ParentPermissionId", "PermissionTitle" },
                values: new object[] { 7, null, "مدیریت نقش ها" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "ParentPermissionId", "PermissionTitle" },
                values: new object[,]
                {
                    { 3, 2, "افزودن کاربر" },
                    { 4, 2, "ویرایش کاربر" },
                    { 5, 2, "حذف کاربر" },
                    { 6, 2, "تغییر رمز عبور کاربر" },
                    { 8, 7, "افزودن نقش جدید" },
                    { 9, 7, "ویرایش نقش" },
                    { 10, 7, "حذف نقش" },
                    { 11, 2, "تغییر دسترسی های کاربر" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 7);
        }
    }
}
