using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.ICommands
{
    public interface IEstadoCommand
    {
        Task<Estado> Insert(Estado element);
        Task<Estado> Update(Estado element);
        Task Delete(Estado element);
    }
}
