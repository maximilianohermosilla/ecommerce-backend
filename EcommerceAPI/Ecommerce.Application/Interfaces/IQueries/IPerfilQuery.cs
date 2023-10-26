using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.IQueries
{
    public interface IPerfilQuery
    {
        Task<List<Perfil>> GetAll();
        Task<Perfil?> GetById(int id);        
    }
}
