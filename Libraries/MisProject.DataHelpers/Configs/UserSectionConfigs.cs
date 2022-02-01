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
        }
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
    }
}