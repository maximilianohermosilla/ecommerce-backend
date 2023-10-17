namespace Ecommerce.Domain.Entities
{
    public partial class Perfil
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
    }
}
