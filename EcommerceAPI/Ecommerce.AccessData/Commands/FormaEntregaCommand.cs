using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Domain.Entities;

namespace Ecommerce.AccessData.Commands
{
    public class FormaEntregaCommand : IFormaEntregaCommand
    {
        private EcommerceDbContext _context;

        public FormaEntregaCommand(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task Delete(FormaEntrega element)
        {
            _context.FormaEntrega.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task<FormaEntrega> Insert(FormaEntrega element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task<FormaEntrega> Update(FormaEntrega element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();

            return element;
        }
    }
}
