using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Domain.Entities;

namespace Ecommerce.AccessData.Commands
{
    public class EstadoCommand : IEstadoCommand
    {
        private EcommerceDbContext _context;

        public EstadoCommand(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Estado element)
        {
            _context.Estado.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task<Estado> Insert(Estado element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task<Estado> Update(Estado element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();

            return element;
        }
    }
}
