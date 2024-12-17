using Microsoft.EntityFrameworkCore;

namespace WebTeploobmenApp.Data
{
    public class TeploobmenContext : DbContext
    {
        public DbSet<Variant> Variants { get; set; }

        public TeploobmenContext(DbContextOptions<TeploobmenContext> options) : base(options) { }
    }
}
