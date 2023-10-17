namespace Ecommerce.Domain.Entities
{
    public partial class ProductoCaracteristica
    {
        public int Id { get; set; }
        public int IdProductoDetalle { get; set; }
        public int IdCaracteristica { get; set; }

        public virtual ProductoDetalle ProductoDetalle { get; set; }
        public virtual Caracteristica Caracteristica { get; set; }
    }
}
