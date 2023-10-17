namespace Ecommerce.Domain.Entities
{
    public partial class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string? Piso { get; set; }
        public string? Departamento { get; set; }
        public string? Observaciones { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Municipio { get; set; }
        public bool Habilitado { get; set; }
        public bool Principal { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
 
    }
}
