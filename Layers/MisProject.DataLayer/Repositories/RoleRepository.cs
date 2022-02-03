namespace MisProject.DataLayer.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly MisDbContext _db;

    public RoleRepository(MisDbContext db)
    {
        _db = db;
    }


    public async Task<Role?> Create(Role obj)
    {
        var result = await _db.Roles.AddAsync(obj);
        var saveChangesAsync = await _db.SaveChangesAsync();

        return saveChangesAsync > 0
            ? result.Entity
            : null;
    }

    [Obsolete("WARNING: This method will fully delete row!")]
    public async Task<bool> Delete(Role obj)
    {
        _db.Roles.Remove(obj);
        return await _db.SaveChangesAsync() > 0;
    }

    [Obsolete("WARNING: This method will fully delete row!")]
    public async Task<bool> Delete(int id)
    {
        var role = await GetById(id);
        return role != null && await Delete(role);
    }

    public async Task<Role?> Update(Role obj)
    {
        var updatedResult = _db.Roles.Update(obj);
        var saveResult = await _db.SaveChangesAsync();

        return saveResult > 0
            ? updatedResult.Entity
            : null;
    }

    public async Task<IEnumerable<Role?>> GetAll()
        => await _db.Roles.ToListAsync();

    public async Task<Role?> GetById(int id)
        => await _db.Roles.FindAsync(id);
}