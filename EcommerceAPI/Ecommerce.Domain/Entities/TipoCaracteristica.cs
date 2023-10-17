namespace Ecommerce.Domain.Entities
{
    public partial class TipoCaracteristica
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public int IdCategoriaProducto { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }
        public virtual ICollection<Caracteristica> Caracteristicas { get; set; }
    }
}
