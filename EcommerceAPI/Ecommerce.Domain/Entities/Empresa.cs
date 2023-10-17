namespace Ecommerce.Domain.Entities
{
    public partial class Empresa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<ProductoDetalle> ProductoDetalles { get; set; }
        public virtual ICollection<PromocionCategoria> PromocionCategorias { get; set; }
    }
}
