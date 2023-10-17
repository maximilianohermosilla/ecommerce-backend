namespace Ecommerce.Domain.Entities
{
    public partial class CategoriaProducto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public virtual IList<Producto> Productos { get; set; }
        public virtual IList<PromocionCategoria> PromocionCategorias { get; set; }
        public virtual IList<TipoCaracteristica> TipoCaracteristicas { get; set; }

    }
}
