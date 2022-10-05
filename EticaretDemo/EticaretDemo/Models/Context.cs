using Microsoft.EntityFrameworkCore;

namespace EticaretDemo.Models
{
    public class Context:DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
        }
    }
}
