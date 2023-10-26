namespace Ecommerce.Application.Models
{
    public partial class CarritoRequest
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int IdProductoDetalle { get; set; }
        public int IdUsuario { get; set; }
    }
}
