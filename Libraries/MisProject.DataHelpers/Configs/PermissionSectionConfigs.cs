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

    public static void ConfigPermissionSection(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>(p => p.HasData(PermissionSeedList));

        modelBuilder.Entity<RolePermission>(p =>
        {
            p.HasQueryFilter(x => !x.Role.IsDeleted);
        });
    }
}