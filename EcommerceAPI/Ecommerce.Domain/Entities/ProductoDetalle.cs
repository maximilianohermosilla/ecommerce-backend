namespace Ecommerce.Domain.Entities
{
    public partial class ProductoDetalle
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public bool Habilitado { get; set; }

        public virtual Producto IdProducto { get; set; }
        public virtual Empresa IdEmpresa { get; set; }
    }
}
