using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Domain.Entities;

namespace Ecommerce.AccessData.Commands
{
    public class EmpresaCommand : IEmpresaCommand
    {
        private EcommerceDbContext _context;

        public EmpresaCommand(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Empresa element)
        {
            _context.Empresa.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task<Empresa> Insert(Empresa element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task<Empresa> Update(Empresa element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();

            return element;
        }
    }
}
