using Microsoft.EntityFrameworkCore;
using MisProject.DTOs.Entities.Users;
using MisProject.Helpers.Converters;

namespace MisProject.DataHelpers.Configs;

public static class UserSectionConfigs
{
    public static readonly List<Role> RoleSeedList = new()
    {
        new Role(1, "مدیر وبسایت"),
        new Role(2, "کاربر")
    };

    public static readonly List<User> UserSeedList = new()
    {
        new User()
        {
            UserId = 1,
            UserName = "Admin",
            // Get password from Mis.Password, otherwise set to AdminAdmin (Hash salt: MySalt)
            Password = Environment.GetEnvironmentVariable("Mis.Password") ?? "045e9902f2aca62f48117c43dfbd18cb",
            Email = "Admin@Admin.com",
            FirstName = "Admin",
            LastName = "Admin",
            IsEmailConfirmed = true,
            IsPhoneNumberConfirmed = true,
            IsDeleted = false,
            ActiveCode = "4774d6cf92a744f9b181609003b31e7d",
            IdentityCode = "045f5b119de54909ab6630eae9a0b532",
            RegisterTime = new DateTime(2022, 2, 1, 17, 1, 10, 967, DateTimeKind.Local).AddTicks(1720),
        },
        new User()
        {
            UserId = 2,
            UserName = "User 2",
            // Password=password (salt MySalt)
            Password = "471e5243d0db300de1019fed26d3ffb1",
            Email = "User2@Users.com",
            FirstName = "User",
            LastName = "Usr2",
            IsEmailConfirmed = true,
            IsPhoneNumberConfirmed = true,
            IsDeleted = false,
            ActiveCode = "384528b9580f4acfbcc90f2f25ce08b7",
            IdentityCode = "0dcb7d233a064c5580269c07a15bfaf3",
            RegisterTime = new DateTime(2022, 2, 1, 17, 1, 10, 974, DateTimeKind.Local).AddTicks(8386),
        },
        new User()
        {
            UserId = 3,
            UserName = "User 3",
            // Password=password (salt MySalt)
            Password = "471e5243d0db300de1019fed26d3ffb1",
            Email = "User3@Users.com",
            FirstName = "User",
            LastName = "Usr3",
            IsEmailConfirmed = true,
            IsPhoneNumberConfirmed = true,
            IsDeleted = false,
            ActiveCode = "1191b1fe89924cc2b6e47af84b1eb0a0",
            IdentityCode = "7cf1a61f722941b289e2c6a31983dcd3",
            RegisterTime = new DateTime(2022, 2, 1, 17, 1, 10, 974, DateTimeKind.Local).AddTicks(8753),
        }
    };

    public static readonly List<UserRole> UserRoleSeedList = new()
    {
        new UserRole(1, 1) { UserRoleId = 1 },
        new UserRole(2, 2) { UserRoleId = 2 },
        new UserRole(3, 2) { UserRoleId = 3 },
    };

    public static void ConfigUsersSection(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(u =>
        {
            u.HasData(UserSeedList);

            u.HasQueryFilter(p => !p.IsDeleted);
        });

        modelBuilder.Entity<Role>(r =>
        {
            r.HasData(RoleSeedList);

            r.HasQueryFilter(p => !p.IsDeleted);
        });

        modelBuilder.Entity<UserRole>(ur =>
        {
            ur.HasData(UserRoleSeedList);

            ur.HasQueryFilter(p => !p.Role.IsDeleted && !p.User.IsDeleted);
        });
    }
}