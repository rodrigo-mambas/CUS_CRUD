using CUS.Cliente.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CUS.Cliente.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public DbSet<CUS.Cliente.API.Models.Cliente> Clientes { get; set; }
    }
}
