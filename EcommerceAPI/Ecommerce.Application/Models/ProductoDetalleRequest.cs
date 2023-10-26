namespace Ecommerce.Application.Models
{
    public partial class ProductoDetalleRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public bool Habilitado { get; set; }  
        public int IdProducto { get; set; }
        public int IdEmpresa { get; set; }
    }
}
