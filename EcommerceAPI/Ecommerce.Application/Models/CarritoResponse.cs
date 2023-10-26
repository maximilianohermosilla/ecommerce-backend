namespace Ecommerce.Application.Models
{
    public partial class CarritoResponse
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public ProductoDetalleResponse ProductoDetalle { get; set; }
    }
}
