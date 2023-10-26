namespace Ecommerce.Application.Models
{
    public partial class PedidoResponse
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public float PrecioTotal { get; set; }
        public bool Habilitado { get; set; }        
        public EstadoResponse Estado { get; set; }
        public FormaEntregaResponse FormaEntrega { get; set; }
        public FormaPagoResponse FormaPago { get; set; }
        public UsuarioResponse Usuario { get; set; }
        public DireccionResponse Direccion { get; set; }
        public List<PedidoDetalleResponse> PedidoDetalles { get; set; }
        public List<EstadoPedidoResponse> Estados { get; set; }
    }
}
