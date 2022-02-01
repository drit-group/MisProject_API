using Microsoft.EntityFrameworkCore;
using MisProject.DTOs.Entities.Users;

namespace MisProject.DataHelpers.Configs;

public static class UserSectionConfigs
{
    public static readonly List<Role> RoleSeedList = new()
    {
        new Role(1, "مدیر وبسایت"),
        new Role(2, "کاربر")
    };

    public static void ConfigUsersSection(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(r =>
        {
            r.HasData(RoleSeedList);

            r.HasQueryFilter(p => !p.IsDeleted);
        });
    }
}