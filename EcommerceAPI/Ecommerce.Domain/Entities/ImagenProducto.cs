namespace Ecommerce.Domain.Entities
{
    public partial class ImagenProducto
    {
        public int Id { get; set; }
        public string NombreArchivo { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }
        public bool Principal { get; set; }

        public virtual Producto IdProducto { get; set; 
    }
}
