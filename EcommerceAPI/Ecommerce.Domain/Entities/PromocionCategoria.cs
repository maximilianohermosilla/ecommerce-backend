namespace Ecommerce.Domain.Entities
{
    public partial class PromocionCategoria
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public int IdCategoriaProducto { get; set; }
        public int IdPromocion { get; set; }
        public int IdEmpresa { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }
        public virtual Promocion Promocion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
