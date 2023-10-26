namespace Ecommerce.Application.Models
{
    public partial class EstadoPedidoResponse
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoResponse Estado { get; set; }
    }
}
