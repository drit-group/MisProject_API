using MisProject.DataHelpers.Configs;

namespace MisProject.DataLayer.Contexts;

public class MisDbContext : DbContext
{
    public MisDbContext(DbContextOptions<MisDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; } = null!;

    public DbSet<Permission> Permissions { get; set; } = null!;
    public DbSet<RolePermission> RolePermissions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigPermissionSection();
        base.OnModelCreating(modelBuilder);
    }
}