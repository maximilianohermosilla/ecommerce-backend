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

        public virtual CategoriaProducto IdCategoriaProducto { get; set; }
    }
}
