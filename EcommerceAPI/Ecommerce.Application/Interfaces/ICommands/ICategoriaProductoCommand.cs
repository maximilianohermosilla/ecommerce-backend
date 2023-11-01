using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.ICommands
{
    public interface ICategoriaProductoCommand
    {
        Task<CategoriaProducto> Insert(CategoriaProducto element);
        Task<CategoriaProducto> Update(CategoriaProducto element);
        Task Delete(CategoriaProducto element);    
    }
}
