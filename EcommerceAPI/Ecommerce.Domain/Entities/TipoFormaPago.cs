namespace Ecommerce.Domain.Entities
{
    public partial class TipoFormaPago
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<FormaPago> FormaPagos { get; set; }
    }
}
