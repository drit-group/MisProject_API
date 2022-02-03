namespace MisProject.DataLayer.Repositories.Interfaces;

public interface IRoleRepository : ICrudGenericAsync<Role>
{
    [Obsolete("WARNING: This method will fully delete row!")]
    new Task<bool> Delete(Role obj);

    [Obsolete("WARNING: This method will fully delete row!")]
    new Task<bool> Delete(int id);
}