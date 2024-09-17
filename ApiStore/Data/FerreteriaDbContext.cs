using ApiStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Data;


    public class FerreteriaContext : DbContext
    {
        public FerreteriaContext(DbContextOptions<FerreteriaContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<DetallePedido> detalle_pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Usuario)//Tiene uno
                .WithMany(u => u.Pedidos)//Con muchos
                .HasForeignKey(p => p.usuario_id);//clave foránea

       
        modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Pedido)
                .WithMany(p => p.DetallesPedido)
                .HasForeignKey(dp => dp.pedido_id);

            
            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Producto)
                .WithMany(p => p.DetallesPedido)
                .HasForeignKey(dp => dp.producto_id);

            
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.categoria_id);
        }
    }


