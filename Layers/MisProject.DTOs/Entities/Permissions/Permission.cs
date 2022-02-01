namespace MisProject.DTOs.Entities.Permissions;

public class Permission
{
    public Permission()
    {
    }

    public Permission(string permissionTitle, int? parentPermissionId = null) : this()
    {
        PermissionTitle = permissionTitle;
        ParentPermissionId = parentPermissionId;
    }

    public Permission(int permissionId, string permissionTitle, int? parentPermissionId = null) : this(permissionTitle,
        parentPermissionId)
    {
        PermissionId = permissionId;
    }


    [Key] public int PermissionId { get; set; }

    [Required, MinLength(3), MaxLength(200)]
    public string PermissionTitle { get; set; } = null!;

    public int? ParentPermissionId { get; set; }



    #region Relations

    public Permission? ParentPermission { get; set; }

    public ICollection<RolePermission> RolePermissions { get; set; } = null!;

    #endregion
}