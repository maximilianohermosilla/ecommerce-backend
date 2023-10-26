namespace Ecommerce.Application.Models
{
    public partial class PedidoRequest
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
    }
}
