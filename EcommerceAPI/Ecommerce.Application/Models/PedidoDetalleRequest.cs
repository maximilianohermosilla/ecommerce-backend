namespace Ecommerce.Application.Models
{
    public partial class PedidoDetalleRequest
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Descuento { get; set; }
        public float PrecioFinal { get; set; }        
        public int IdProductoDetalle { get; set; }
        public int IdPedido { get; set; }
    }
}
