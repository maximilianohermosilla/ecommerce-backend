namespace Ecommerce.Domain.Entities
{
    public partial class ProductoDetalle
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public bool Habilitado { get; set; }
        public int IdProducto { get; set; }
        public int IdEmpresa { get; set; }
        
        public virtual Producto Producto { get; set; }
        public virtual Empresa Empresa { get; set; }

        public virtual IList<ProductoCaracteristica> ProductoCaracteristicas { get; set; }
        public virtual IList<Carrito> Carritos { get; set; }
        public virtual IList<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
