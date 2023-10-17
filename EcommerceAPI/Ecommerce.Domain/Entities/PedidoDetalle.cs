namespace Ecommerce.Domain.Entities
{
    public partial class PedidoDetalle
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Descuento { get; set; }
        public float PrecioFinal { get; set; }
        public int IdProductoDetalle { get; set; }
        public int IdPedido { get; set; }
        
        public virtual ProductoDetalle ProductoDetalle { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
