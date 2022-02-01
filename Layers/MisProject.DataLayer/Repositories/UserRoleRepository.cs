namespace MisProject.DataLayer.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly MisDbContext _db;

    public UserRoleRepository(MisDbContext db)
    {
        _db = db;
    }


    public async Task<UserRole?> Create(UserRole obj)
    {
        var result = await _db.UserRoles.AddAsync(obj);
        var saveChangesAsync = await _db.SaveChangesAsync();

        return saveChangesAsync > 0
            ? result.Entity
            : null;
    }

    public async Task<bool> Delete(UserRole obj)
    {
        _db.UserRoles.Remove(obj);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<UserRole?> Update(UserRole obj)
    {
        var updatedResult = _db.UserRoles.Update(obj);
        var saveResult = await _db.SaveChangesAsync();

        return saveResult > 0
            ? updatedResult.Entity
            : null;
    }

    public async Task<IEnumerable<UserRole?>> GetAll()
        => await _db.UserRoles.ToListAsync();

    public async Task<UserRole?> GetById(int id)
        => await _db.UserRoles.FindAsync(id);
}