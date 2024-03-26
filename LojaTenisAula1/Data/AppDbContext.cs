using LojaTenisAula1.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaTenisAula1.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {          
        }


        public DbSet<TenisModel> Tenis { get; set; }

    }
}
