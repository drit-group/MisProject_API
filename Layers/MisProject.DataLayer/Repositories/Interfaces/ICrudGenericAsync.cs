namespace MisProject.DataLayer.Repositories.Interfaces;

public interface ICrudGenericAsync<T>
{
    Task<T?> Create(T obj);

    Task<bool> Delete(T obj);
    Task<bool> Delete(int id);

    Task<T?> Update(T obj);

    Task<IEnumerable<T?>> GetAll();

    Task<T?> GetById(int id);
}