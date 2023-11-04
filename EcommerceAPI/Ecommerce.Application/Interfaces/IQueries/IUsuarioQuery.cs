using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.IQueries
{
    public interface IUsuarioQuery
    {
        Task<List<Usuario>> GetAll(bool fullResponse);
        Task<Usuario?> GetById(int id, bool fullResponse);
        Task<Usuario?> GetByUser(string user);
        Task<Usuario?> GetByEmail(string email);
    }
}
