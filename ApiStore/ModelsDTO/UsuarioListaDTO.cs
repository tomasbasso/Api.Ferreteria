using System.ComponentModel.DataAnnotations;

namespace ApiStore.Models
{
    public class UsuarioListaDTO
    {
        [Key]
        public int usuario_id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string rol { get; set; }
    }
}