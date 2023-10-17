namespace Ecommerce.Domain.Entities
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? DNI { get; set; }
        public string? TelefonoPrincipal { get; set; }
        public string? TelefonoSecundario { get; set; }
        public string? Imagen { get; set; }
        public bool Habilitado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdPerfil { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual IList<FormaPago> FormaPagos { get; set; }
        public virtual IList<Pedido> Pedidos { get; set; }
        public virtual IList<Carrito> Carritos { get; set; }
        public virtual IList<Opinion> Opiniones { get; set; }
        public virtual IList<Direccion> Direcciones { get; set; }
    }
}
