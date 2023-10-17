namespace Ecommerce.Domain.Entities
{
    public partial class EstadoPedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Pedido IdPedido { get; set; }
        public virtual Estado IdEstado { get; set; }
    }
}
