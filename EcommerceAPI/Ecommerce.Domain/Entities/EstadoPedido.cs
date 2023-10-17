namespace Ecommerce.Domain.Entities
{
    public partial class EstadoPedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPedido { get; set; }
        public int IdEstado { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
