namespace Ecommerce.Domain.Entities
{
    public partial class Carrito
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }

        public virtual ProductoDetalle IdProductoDetalle { get; set; }
        public virtual Usuario IdUsuario { get; set; }
    }
}
