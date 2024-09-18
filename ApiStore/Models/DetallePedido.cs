using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
namespace ApiStore.Models
{
    public class DetallePedido
    {
       
    [Key]
        public int detalle_id { get; set; }

        // Relación con Pedido
        public int pedido_id { get; set; }
        //public Pedido Pedido { get; set; }

        // Relación con Producto
        public int producto_id { get; set; }
        //public Producto Producto { get; set; }

        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
    }
}

