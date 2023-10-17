namespace Ecommerce.Domain.Entities
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public float PrecioTotal { get; set; }
        public bool Habilitado { get; set; }

        public virtual Estado IdEstado { get; set; }
        public virtual FormaEntrega IdFormaEntrega { get; set; }
        public virtual FormaPago IdFormaPago { get; set; }
        public virtual Usuario IdUsuario { get; set; }
        public virtual Direccion IdDireccion { get; set; }
    }
}
