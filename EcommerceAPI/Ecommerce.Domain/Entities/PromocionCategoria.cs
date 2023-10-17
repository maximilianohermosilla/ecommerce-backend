namespace Ecommerce.Domain.Entities
{
    public partial class PromocionCategoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public virtual CategoriaProducto IdCategoriaProducto { get; set; }
        public virtual Promocion IdPromocion { get; set; }
        public virtual Empresa IdEmpresa { get; set; }
    }
}
