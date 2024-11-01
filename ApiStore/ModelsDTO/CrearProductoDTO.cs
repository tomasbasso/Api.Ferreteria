namespace ApiStore.ModelsDTO
{
    public class CrearProductoDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public int categoria_id { get; set; }
        public string marca { get; set; }
        public string imagen { get; set; }
    }
}
