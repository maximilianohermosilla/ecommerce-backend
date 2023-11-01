using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.IQueries
{
    public interface IFormaEntregaQuery
    {
        Task<List<FormaEntrega>> GetAll();
        Task<FormaEntrega?> GetById(int id);        
    }
}
