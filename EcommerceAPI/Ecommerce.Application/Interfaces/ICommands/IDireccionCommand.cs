using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.ICommands
{
    public interface IDireccionCommand
    {
        Task<Direccion> Insert(Direccion element);
        Task<Direccion> Update(Direccion element);
        Task Delete(Direccion element);
    }
}
