namespace Ecommerce.Domain.Entities
{
    public partial class Carrito
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int IdProductoDetalle { get; set; }
        public int IdUsuario { get; set; }

        public virtual ProductoDetalle ProductoDetalle { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
