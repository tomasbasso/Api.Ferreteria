using System.ComponentModel.DataAnnotations;
namespace ApiStore.Models
{
    public class Categoria
    {
        [Key]
        public int categoria_id { get; set; }
        public string nombre { get; set; }

        // Relación con Productos
        //public ICollection<Producto> Productos { get; set; }
    }
}
