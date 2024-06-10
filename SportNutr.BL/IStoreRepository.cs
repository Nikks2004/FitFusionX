using System.Linq;

namespace SportNutr.BL
{
    public interface IStoreRepository
    {
        // Adds a new entity to the context
        void Add<T>(T entity) where T : class;

        // Saves all changes made in this context to the database
        void CommitChanges();

        // Gets a queryable for a specific entity type
        IQueryable<T> Query<T>() where T : class;
    }
}