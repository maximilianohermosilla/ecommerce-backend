namespace Ecommerce.Application.Models
{
    public partial class ImagenProductoResponse
    {
        public int Id { get; set; }
        public string? NombreArchivo { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }
        public bool Principal { get; set; }
    }
}
