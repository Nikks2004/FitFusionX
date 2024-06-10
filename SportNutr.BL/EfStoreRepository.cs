using System.Linq;
using SportNutr.Db;

namespace SportNutr.BL
{
    public class EfStoreRepository : IStoreRepository
    {
        private readonly SportsNutritionDbContext _context;

        public EfStoreRepository(SportsNutritionDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>();
        }
    }
}