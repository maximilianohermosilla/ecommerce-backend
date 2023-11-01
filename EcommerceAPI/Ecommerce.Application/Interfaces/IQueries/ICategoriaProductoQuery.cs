using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.IQueries
{
    public interface ICategoriaProductoQuery
    {
        Task<List<CategoriaProducto>> GetAll();
        Task<CategoriaProducto?> GetById(int id);        
    }
}
