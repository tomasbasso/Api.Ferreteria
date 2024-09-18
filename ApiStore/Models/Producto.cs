using System.ComponentModel.DataAnnotations;
namespace ApiStore.Models
{
    public class Producto
    {
        [Key]
        public int producto_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }

        // Relación con Categoria
        public int categoria_id { get; set; }
        //public Categoria Categoria { get; set; }

        public string marca { get; set; }

        // Relación con DetallePedido
        //public ICollection<DetallePedido> DetallesPedido { get; set; }
    }
}
