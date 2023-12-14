using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Domain.Entities;

namespace Ecommerce.AccessData.Commands
{
    public class DireccionCommand : IDireccionCommand
    {
        private EcommerceDbContext _context;

        public DireccionCommand(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Direccion element)
        {
            _context.Direccion.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task<Direccion> Insert(Direccion element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task<Direccion> Update(Direccion element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();

            return element;
        }
    }
}
