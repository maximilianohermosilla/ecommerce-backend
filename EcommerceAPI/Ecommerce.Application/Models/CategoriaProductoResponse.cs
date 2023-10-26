namespace Ecommerce.Application.Models
{
    public partial class CategoriaProductoResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public PromocionCategoriaResponse? PromocionCategoria { get; set; }
    }
}
