namespace Ecommerce.Application.Models
{
    public partial class UsuarioRequest
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
    }
}
