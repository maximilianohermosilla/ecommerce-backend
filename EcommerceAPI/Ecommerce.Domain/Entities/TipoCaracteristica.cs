namespace Ecommerce.Domain.Entities
{
    public partial class TipoCaracteristica
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public virtual CategoriaProducto IdCategoriaProducto { get; set; }
    }
}
