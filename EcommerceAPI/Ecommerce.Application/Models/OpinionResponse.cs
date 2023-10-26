namespace Ecommerce.Application.Models
{
    public partial class OpinionResponse
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int Puntos { get; set; }
        public UsuarioResponse Usuario { get; set; }
    }
}
