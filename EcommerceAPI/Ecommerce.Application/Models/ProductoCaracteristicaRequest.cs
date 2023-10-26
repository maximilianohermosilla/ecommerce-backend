namespace Ecommerce.Application.Models
{
    public partial class ProductoCaracteristicaRequest
    {
        public int Id { get; set; }
        public int IdProductoDetalle { get; set; }
        public int IdCaracteristica { get; set; }
    }
}
