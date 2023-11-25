using Microsoft.EntityFrameworkCore;
using WebApplicationDapper.Models;

namespace WebApplicationDapper.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<CompanyModel> Companies { get; set; }
    }
}
