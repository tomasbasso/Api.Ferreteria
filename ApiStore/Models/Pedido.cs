using System.ComponentModel.DataAnnotations;
namespace ApiStore.Models
{
    public class Pedido
    {
        [Key]
        public int pedido_id { get; set; }

        // Relación con Usuario
        public int usuario_id { get; set; }
        //public Usuario Usuario { get; set; }

        public decimal precio_total { get; set; }
        public DateTime fecha { get; set; }

        // Relación con DetallePedido
        //public ICollection<DetallePedido> DetallesPedido { get; set; }
    }
}
