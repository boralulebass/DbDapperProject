using DbDapperProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DbDapperProject.EFContext
{
    public class ContextEF : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-B6KHCGR\\SQLEXPRESS;initial catalog=CARPLATES;integrated security=true;TrustServerCertificate=true");
        }
        public DbSet<CarPlate> PLATES { get; set; }


    }
}
