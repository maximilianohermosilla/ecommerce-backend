namespace Ecommerce.Domain.Entities
{
    public partial class Promocion
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int Cuotas { get; set; }
        public int Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual IList<PromocionCategoria> PromocionCategorias { get; set; }
        public virtual IList<PromocionProducto> PromocionProductos { get; set; }
    }
}
