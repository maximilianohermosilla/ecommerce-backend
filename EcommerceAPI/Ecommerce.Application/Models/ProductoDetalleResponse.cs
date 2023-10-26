namespace Ecommerce.Application.Models
{
    public partial class ProductoDetalleResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public bool Habilitado { get; set; }
        public EmpresaResponse Empresa { get; set; }
    }
}
