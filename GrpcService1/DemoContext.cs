using GrpcService1.Model;
using Microsoft.EntityFrameworkCore;

namespace GrpcService1
{
    public class DemoContext:DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options):base(options)
        {

        }
        public DbSet<Model.Users> Users { get; set; }
        public DbSet<Titles> Titles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Users>().HasKey(o => o.Id);
            
            modelBuilder.Entity<Titles>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
