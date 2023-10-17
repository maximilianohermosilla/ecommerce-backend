namespace Ecommerce.Domain.Entities
{
    public partial class Caracteristica
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public virtual TipoCaracteristica IdTipoCaracteristica { get; set; }
    }
}
