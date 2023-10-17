namespace Ecommerce.Domain.Entities
{
    public partial class Estado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<EstadoPedido> EstadoPedidos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
