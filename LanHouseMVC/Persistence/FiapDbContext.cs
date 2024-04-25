using LanHouseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LanHouseMVC.Persistence
{
    public class FiapDbContext : DbContext
    {
        public FiapDbContext(DbContextOptions<FiapDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<LanHouseMVC.Models.Computador> Computador { get; set; } = default!;
        public DbSet<LanHouseMVC.Models.Periferico> Periferico { get; set; } = default!;
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<LanHouseMVC.Models.InfoContato> InfoContato { get; set; } = default!;
    }
}
