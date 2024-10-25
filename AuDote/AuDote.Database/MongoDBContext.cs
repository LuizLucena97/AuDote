using AuDote.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AuDote.Database
{
    public class MongoDbContext : DbContext
    {
        public DbSet<Cachorro> Cachorros { get; set; }

        public MongoDbContext(DbContextOptions<MongoDbContext> options) : base(options)
        {

        }
    }
}
