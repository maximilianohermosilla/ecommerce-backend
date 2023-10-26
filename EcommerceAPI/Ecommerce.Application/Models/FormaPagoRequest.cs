namespace Ecommerce.Application.Models
{
    public partial class FormaPagoRequest
    {
        public int Id { get; set; }
        public string Entidad { get; set; }
        public string Numero { get; set; }
        public string Expiracion { get; set; }
        public bool Habilitado { get; set; }
        public bool Principal { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoFormaPago { get; set; }
    }
}
