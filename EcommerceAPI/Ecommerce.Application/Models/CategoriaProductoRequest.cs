namespace Ecommerce.Application.Models
{
    public partial class CategoriaProductoRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
}
