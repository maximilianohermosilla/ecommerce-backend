using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.ICommands
{
    public interface IPerfilCommand
    {
        Task<Perfil> Insert(Perfil element);
        Task<Perfil> Update(Perfil element);
        Task Delete(Perfil element);
    }
}
