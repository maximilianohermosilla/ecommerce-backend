namespace Ecommerce.Domain.Entities
{
    public partial class Opinion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Puntos { get; set; }

        public virtual Producto IdProducto { get; set; }
        public virtual Usuario IdUsuario { get; set; }
    }
}
