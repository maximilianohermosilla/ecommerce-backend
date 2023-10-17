namespace Ecommerce.Domain.Entities
{
    public partial class FormaPago
    {
        public int Id { get; set; }
        public string Entidad { get; set; }
        public string Numero { get; set; }
        public string Expiracion { get; set; }
        public bool Habilitado { get; set; }
        public bool Principal { get; set; }

        public virtual Usuario IdUsuario { get; set; }
        public virtual TipoFormaPago IdTipoFormaPago { get; set; }
    }
}
