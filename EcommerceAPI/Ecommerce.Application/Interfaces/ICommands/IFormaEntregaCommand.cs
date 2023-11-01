using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.ICommands
{
    public interface IFormaEntregaCommand
    {
        Task<FormaEntrega> Insert(FormaEntrega element);
        Task<FormaEntrega> Update(FormaEntrega element);
        Task Delete(FormaEntrega element);    
    }
}
