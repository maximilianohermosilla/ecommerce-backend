namespace Ecommerce.Application.Models
{
    public partial class ProductoCaracteristicaResponse
    {
        public int Id { get; set; }
        public int IdProductoDetalle { get; set; }
        public virtual CaracteristicaResponse Caracteristica { get; set; }
    }
}
