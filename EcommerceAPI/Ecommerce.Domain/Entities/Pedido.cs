namespace Ecommerce.Domain.Entities
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public float PrecioTotal { get; set; }
        public bool Habilitado { get; set; }
        public int IdEstado { get; set; }
        public int IdFormaEntrega { get; set; }
        public int IdFormaPago { get; set; }
        public int IdUsuario { get; set; }
        public int IdDireccion { get; set; }
        
        public virtual Estado Estado { get; set; }
        public virtual FormaEntrega FormaEntrega { get; set; }
        public virtual FormaPago FormaPago { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Direccion Direccion { get; set; }

        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
        public virtual ICollection<EstadoPedido> EstadoPedidos { get; set; }
    }
}
