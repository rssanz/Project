using DataEntities.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data_EF.Contexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        { }

        public DbSet<Rate> Rate { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
