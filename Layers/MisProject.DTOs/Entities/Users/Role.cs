using MisProject.DTOs.Entities.Permissions;

namespace MisProject.DTOs.Entities.Users;

public class Role
{
    public Role()
    {
        
    }

    public Role(int roleId, string roleName) : this()
    {
        RoleId = roleId;
        RoleName = roleName;
    }

    [Key] public int RoleId { get; set; }

    [Required, MinLength(3), MaxLength(20)]
    public string RoleName { get; set; } = null!;

    public bool IsDeleted { get; set; }


    #region Relations

    public ICollection<UserRole> UserRoles { get; set; } = null!;
    public ICollection<RolePermission> RolePermissions { get; set; } = null!;

    #endregion
}