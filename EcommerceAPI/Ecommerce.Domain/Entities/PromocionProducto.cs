namespace Ecommerce.Domain.Entities
{
    public partial class PromocionProducto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public virtual Producto IdProducto { get; set; }
        public virtual Promocion IdPromocion { get; set; }
    }
}
