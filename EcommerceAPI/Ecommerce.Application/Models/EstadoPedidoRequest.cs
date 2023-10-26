namespace Ecommerce.Application.Models
{
    public partial class EstadoPedidoRequest
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPedido { get; set; }
        public int IdEstado { get; set; }
    }
}
