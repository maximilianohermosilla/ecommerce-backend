using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.IQueries
{
    public interface IDireccionQuery
    {
        Task<List<Direccion>> GetAllByUser(int idUsuario);
        Task<Direccion?> GetById(int id);        
    }
}
