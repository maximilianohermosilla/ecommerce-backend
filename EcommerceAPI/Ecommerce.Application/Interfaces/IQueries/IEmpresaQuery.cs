using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.IQueries
{
    public interface IEmpresaQuery
    {
        Task<List<Empresa>> GetAll();
        Task<Empresa?> GetById(int id);        
    }
}
