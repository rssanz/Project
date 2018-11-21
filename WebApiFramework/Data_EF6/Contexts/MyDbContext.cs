using DataEntities.Domain;
using System.Data.Entity;

namespace Data_EF.Contexts
{
    public class MyDbContext : DbContext, IDbContext
    {
        public MyDbContext() { }
        public MyDbContext(string connection) : base(connection)
        {

        }
        public MyDbContext(MyDbContext options) { }

        public DbSet<Rate> Rate { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
