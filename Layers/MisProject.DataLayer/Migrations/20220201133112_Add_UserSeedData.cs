using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MisProject.DataLayer.Migrations
{
    public partial class Add_UserSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ActiveCode", "Address", "BirthDay", "Email", "FatherName", "FirstName", "FixedEmail", "FixedUserName", "HomeNumber", "IdentityCode", "Interests", "IsDeleted", "IsEmailConfirmed", "IsPhoneNumberConfirmed", "LastName", "NationalCode", "Password", "PhoneNumber", "RegisterTime", "TelegramId", "UserName" },
                values: new object[] { 1, "4774d6cf92a744f9b181609003b31e7d", null, null, "Admin@Admin.com", null, "Admin", "ADMIN@ADMIN.COM", "ADMIN", null, "045f5b119de54909ab6630eae9a0b532", null, false, true, true, "Admin", null, "045e9902f2aca62f48117c43dfbd18cb", null, new DateTime(2022, 2, 1, 17, 1, 10, 967, DateTimeKind.Local).AddTicks(1720), null, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ActiveCode", "Address", "BirthDay", "Email", "FatherName", "FirstName", "FixedEmail", "FixedUserName", "HomeNumber", "IdentityCode", "Interests", "IsDeleted", "IsEmailConfirmed", "IsPhoneNumberConfirmed", "LastName", "NationalCode", "Password", "PhoneNumber", "RegisterTime", "TelegramId", "UserName" },
                values: new object[] { 2, "384528b9580f4acfbcc90f2f25ce08b7", null, null, "User2@Users.com", null, "User", "USER2@USERS.COM", "USER 2", null, "0dcb7d233a064c5580269c07a15bfaf3", null, false, true, true, "Usr2", null, "471e5243d0db300de1019fed26d3ffb1", null, new DateTime(2022, 2, 1, 17, 1, 10, 974, DateTimeKind.Local).AddTicks(8386), null, "User 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ActiveCode", "Address", "BirthDay", "Email", "FatherName", "FirstName", "FixedEmail", "FixedUserName", "HomeNumber", "IdentityCode", "Interests", "IsDeleted", "IsEmailConfirmed", "IsPhoneNumberConfirmed", "LastName", "NationalCode", "Password", "PhoneNumber", "RegisterTime", "TelegramId", "UserName" },
                values: new object[] { 3, "1191b1fe89924cc2b6e47af84b1eb0a0", null, null, "User3@Users.com", null, "User", "USER3@USERS.COM", "USER 3", null, "7cf1a61f722941b289e2c6a31983dcd3", null, false, true, true, "Usr3", null, "471e5243d0db300de1019fed26d3ffb1", null, new DateTime(2022, 2, 1, 17, 1, 10, 974, DateTimeKind.Local).AddTicks(8753), null, "User 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
