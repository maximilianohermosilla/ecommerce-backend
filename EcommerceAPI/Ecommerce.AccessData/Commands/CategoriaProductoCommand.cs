using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Domain.Entities;

namespace Ecommerce.AccessData.Commands
{
    public class CategoriaProductoCommand : ICategoriaProductoCommand
    {
        private EcommerceDbContext _context;

        public CategoriaProductoCommand(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task Delete(CategoriaProducto element)
        {
            _context.CategoriaProducto.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoriaProducto> Insert(CategoriaProducto element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task<CategoriaProducto> Update(CategoriaProducto element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();

            return element;
        }
    }
}
