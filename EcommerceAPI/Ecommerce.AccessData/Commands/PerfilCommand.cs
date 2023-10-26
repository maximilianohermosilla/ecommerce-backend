using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Domain.Entities;

namespace Ecommerce.AccessData.Commands
{
    public class PerfilCommand : IPerfilCommand
    {
        private EcommerceDbContext _context;

        public PerfilCommand(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Perfil element)
        {
            _context.Perfil.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task<Perfil> Insert(Perfil element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task<Perfil> Update(Perfil element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();

            return element;
        }
    }
}
