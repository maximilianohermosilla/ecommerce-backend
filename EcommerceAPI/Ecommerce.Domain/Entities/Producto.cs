namespace Ecommerce.Domain.Entities
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Habilitado { get; set; }
        public int IdCategoriaProducto { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }

        public virtual IList<ProductoDetalle> ProductoDetalles { get; set; }
        public virtual IList<PromocionProducto> PromocionProductos { get; set; }
        public virtual IList<ImagenProducto> ImagenProductos { get; set; }
        public virtual IList<Opinion> Opiniones { get; set; }
    }
}
