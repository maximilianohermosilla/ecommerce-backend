using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.IQueries
{
    public interface IEstadoQuery
    {
        Task<List<Estado>> GetAll();
        Task<Estado?> GetById(int id);        
    }
}
