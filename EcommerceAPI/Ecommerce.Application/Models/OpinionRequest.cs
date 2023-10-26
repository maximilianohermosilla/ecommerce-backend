namespace Ecommerce.Application.Models
{
    public partial class OpinionRequest
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int Puntos { get; set; }        
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
    }
}
