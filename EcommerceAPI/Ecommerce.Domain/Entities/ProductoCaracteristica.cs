namespace Ecommerce.Domain.Entities
{
    public partial class ProductoCaracteristica
    {
        public int Id { get; set; }

        public virtual ProductoDetalle IdProductoDetalle { get; set; }
        public virtual Caracteristica IdCaracteristica { get; set; }
    }
}
