using System.ComponentModel.DataAnnotations;

namespace ApiStore.Models
{
    public class Usuario
    {
        [Key]
        public int usuario_id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string rol { get; set; }
        public string contraseña { get; set; }


        // Relación con pedidos
        //public ICollection<Pedido> Pedidos { get; set; }
    }

}
