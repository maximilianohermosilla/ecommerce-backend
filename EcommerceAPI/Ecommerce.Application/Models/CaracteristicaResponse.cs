namespace Ecommerce.Application.Models
{
    public partial class CaracteristicaResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public TipoCaracteristicaResponse TipoCaracteristica { get; set; }
    }
}
