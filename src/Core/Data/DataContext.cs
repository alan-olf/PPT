using Microsoft.EntityFrameworkCore;
using PPT.App.Core.Data.Entities;


namespace PPT.App.Core.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }


        public DbSet<Image> Images { get; set; }
         
    }
}
