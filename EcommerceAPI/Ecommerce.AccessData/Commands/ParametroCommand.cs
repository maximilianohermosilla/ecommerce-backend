using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Domain.Entities;

namespace Ecommerce.AccessData.Commands
{
    public class ParametroCommand : IParametroCommand
    {
        private EcommerceDbContext _context;

        public ParametroCommand(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Parametro element)
        {
            _context.Parametro.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task<Parametro> Insert(Parametro element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task<Parametro> Update(Parametro element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();

            return element;
        }
    }
}
