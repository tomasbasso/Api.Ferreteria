using ApiStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Data;

public class FerreteriaContext : DbContext
{
    public FerreteriaContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Usuario> Usuario { get; set; }

  
}
