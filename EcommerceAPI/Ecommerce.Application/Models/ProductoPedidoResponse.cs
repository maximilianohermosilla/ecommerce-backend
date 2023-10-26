namespace Ecommerce.Application.Models
{
    public partial class ProductoPedidoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Habilitado { get; set; }
        public CategoriaProductoResponse CategoriaProducto { get; set; }
        public PromocionProductoResponse PromocionProducto { get; set; }
    }
}
