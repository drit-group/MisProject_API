namespace MisProject.DataLayer.Repositories.Interfaces;

public interface IUserRepository : ICrudGenericAsync<User>
{
    [Obsolete("WARNING: This method will fully delete row!")]
    new Task<bool> Delete(User obj);

    [Obsolete("WARNING: This method will fully delete row!")]
    new Task<bool> Delete(int id);
}