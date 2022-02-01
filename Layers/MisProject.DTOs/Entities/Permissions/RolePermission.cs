using MisProject.DTOs.Entities.Users;

namespace MisProject.DTOs.Entities.Permissions;

public class RolePermission
{
    public RolePermission()
    {
    }

    public RolePermission(int roleId, int permissionId) : this()
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }

    [Key] public int RolePermissionId { get; set; }

    public int RoleId { get; set; }

    public int PermissionId { get; set; }



    #region Relations

    public Permission Permission { get; set; } = null!;
    public Role Role { get; set; } = null!;

    #endregion
}