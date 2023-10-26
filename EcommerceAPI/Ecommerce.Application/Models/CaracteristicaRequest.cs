namespace Ecommerce.Application.Models
{
    public partial class CaracteristicaRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public int IdTipoCaracteristica { get; set; }
    }
}
