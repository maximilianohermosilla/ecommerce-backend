using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Domain.Entities;

namespace Ecommerce.AccessData.Commands
{
    public class UsuarioCommand : IUsuarioCommand
    {
        private EcommerceDbContext _context;

        public UsuarioCommand(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Insert(Usuario element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task<Usuario> Update(Usuario element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();

            return element;
        }
    }
}
