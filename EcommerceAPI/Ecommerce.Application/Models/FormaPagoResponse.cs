namespace Ecommerce.Application.Models
{
    public partial class FormaPagoResponse
    {
        public int Id { get; set; }
        public string Entidad { get; set; }
        public string Numero { get; set; }
        public string Expiracion { get; set; }
        public bool Habilitado { get; set; }
        public bool Principal { get; set; }
        public TipoFormaPagoResponse TipoFormaPago { get; set; }
    }
}
