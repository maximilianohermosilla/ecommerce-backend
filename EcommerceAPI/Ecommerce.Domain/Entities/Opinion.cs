namespace Ecommerce.Domain.Entities
{
    public partial class Opinion
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int Puntos { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
        
        public virtual Producto Producto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
