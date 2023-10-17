namespace Ecommerce.Domain.Entities
{
    public partial class PromocionProducto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public int IdProducto { get; set; }
        public int IdPromocion { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Promocion Promocion { get; set; }
    }
}
