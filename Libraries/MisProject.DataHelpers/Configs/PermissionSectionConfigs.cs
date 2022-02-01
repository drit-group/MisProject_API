using Microsoft.EntityFrameworkCore;
using MisProject.DTOs.Entities.Permissions;

namespace MisProject.DataHelpers.Configs;

public static class PermissionSectionConfigs
{
    public static readonly List<Permission> PermissionSeedList = new()
    {
        new Permission(1, "پنل مدیریت"),
        //----------------------------------------------------------
        new Permission(2, "مدیریت کاربران"),
        new Permission(3, "افزودن کاربر", 2),
        new Permission(4, "ویرایش کاربر", 2),
        new Permission(5, "حذف کاربر", 2),
        new Permission(6, "تغییر رمز عبور کاربر", 2),
        new Permission(11, "تغییر دسترسی های کاربر", 2),
        //----------------------------------------------------------
        new Permission(7, "مدیریت نقش ها"),
        new Permission(8, "افزودن نقش جدید", 7),
        new Permission(9, "ویرایش نقش", 7),
        new Permission(10, "حذف نقش", 7)
    };

    public static readonly List<RolePermission> RolePermissionSeedList = new()
    {
        new RolePermission(1, 1) { RolePermissionId = 1 },
        new RolePermission(1, 2) { RolePermissionId = 2 },
        new RolePermission(1, 3) { RolePermissionId = 3 },
        new RolePermission(1, 4) { RolePermissionId = 4 },
        new RolePermission(1, 5) { RolePermissionId = 5 },
        new RolePermission(1, 6) { RolePermissionId = 6 },
        new RolePermission(1, 7) { RolePermissionId = 7 },
        new RolePermission(1, 8) { RolePermissionId = 8 },
        new RolePermission(1, 9) { RolePermissionId = 9 },
        new RolePermission(1, 10) { RolePermissionId = 10 },
        new RolePermission(1, 11) { RolePermissionId = 11 },
    };

    public static void ConfigPermissionSection(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>(p => p.HasData(PermissionSeedList));

        modelBuilder.Entity<RolePermission>(p =>
        {
            p.HasData(RolePermissionSeedList);

            p.HasQueryFilter(x => !x.Role.IsDeleted);
        });
    }
}