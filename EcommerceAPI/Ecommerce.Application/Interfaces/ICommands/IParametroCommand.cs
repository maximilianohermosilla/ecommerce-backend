using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.ICommands
{
    public interface IParametroCommand
    {
        Task<Parametro> Insert(Parametro element);
        Task<Parametro> Update(Parametro element);
        Task Delete(Parametro element);
    }
}
