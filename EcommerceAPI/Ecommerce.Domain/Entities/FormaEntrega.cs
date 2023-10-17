namespace Ecommerce.Domain.Entities
{
    public partial class FormaEntrega
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
