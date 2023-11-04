using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.IQueries
{
    public interface IParametroQuery
    {
        Task<List<Parametro>> GetAll();
        Task<Parametro?> GetByKey(string clave);
        Task<Parametro?> GetById(int id);   
    }
}
