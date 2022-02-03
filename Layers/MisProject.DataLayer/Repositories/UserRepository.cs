namespace MisProject.DataLayer.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MisDbContext _db;

    public UserRepository(MisDbContext db)
    {
        _db = db;
    }


    public async Task<User?> Create(User obj)
    {
        var result = await _db.Users.AddAsync(obj);
        var saveChangesAsync = await _db.SaveChangesAsync();

        return saveChangesAsync > 0
            ? result.Entity
            : null;
    }

    [Obsolete("WARNING: This method will fully delete row!")]
    public async Task<bool> Delete(User obj)
    {
        _db.Users.Remove(obj);
        return await _db.SaveChangesAsync() > 0;
    }

    [Obsolete("WARNING: This method will fully delete row!")]
    public async Task<bool> Delete(int id)
    {
        var user = await GetById(id);
        return user != null && await Delete(user);
    }

    public async Task<User?> Update(User obj)
    {
        var updatedResult = _db.Users.Update(obj);
        var saveResult = await _db.SaveChangesAsync();

        return saveResult > 0
            ? updatedResult.Entity
            : null;
    }

    public async Task<IEnumerable<User?>> GetAll() 
        => await _db.Users.ToListAsync();

    public async Task<User?> GetById(int id) 
        => await _db.Users.FindAsync(id);
}