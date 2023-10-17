namespace Ecommerce.Domain.Entities
{
    public partial class Caracteristica
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public int IdTipoCaracteristica { get; set; }

        public virtual TipoCaracteristica TipoCaracteristica { get; set; }
        public virtual IList<ProductoCaracteristica> ProductoCaracteristicas { get; set; }
    }
}
