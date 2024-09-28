using System.ComponentModel.DataAnnotations;

namespace ApiStore.ModelsDTO
{
    public class CrearUsuarioDTO
    {
        [Key]
        //public int usuario_id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string rol { get; set; }
        public string contraseña { get; set; }
    }
}
