using Microsoft.EntityFrameworkCore;
 

namespace PPT.App.Core.Data.Store
{
    public class Store<T> : IStore<T> where T : class
    {
        protected readonly DataContext _dbContext;
        protected DbSet<T> DbSet;

        public Store(DataContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<T>();
            Query = DbSet;
        }

        
        public IQueryable<T> Query { get; }
        
    }
}
