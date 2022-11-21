using CartaoDeVisitas.Model;
using Microsoft.EntityFrameworkCore;

namespace CartaoDeVisitas.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
     : base(options) { }
        public DbSet<CartaoVisita> CartaoVisita { get; set; }
    }
}
