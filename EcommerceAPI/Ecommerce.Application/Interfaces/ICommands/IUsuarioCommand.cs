using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.ICommands
{
    public interface IUsuarioCommand
    {
        Task<Usuario> Insert(Usuario element);
        Task<Usuario> Update(Usuario element);
    }
}
