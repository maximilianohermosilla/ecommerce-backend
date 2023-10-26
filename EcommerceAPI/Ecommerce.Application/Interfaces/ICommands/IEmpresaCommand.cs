using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.ICommands
{
    public interface IEmpresaCommand
    {
        Task<Empresa> Insert(Empresa element);
        Task<Empresa> Update(Empresa element);
        Task Delete(Empresa element);    
    }
}
