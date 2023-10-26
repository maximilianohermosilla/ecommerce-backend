namespace Ecommerce.Application.Models
{
    public partial class PromocionProductoResponse
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public PromocionResponse Promocion { get; set; }
    }
}
