using Microsoft.EntityFrameworkCore;

namespace EticaretDemo.Models
{
    public class Context:DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-ROTCU0Q;initial catalog=EticaretDemo;integrated security=true");
        }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Sepet> Sepet { get; set; }

    }
}
