using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.AccessData.Queries
{
    public class FormaEntregaQuery : IFormaEntregaQuery
    {
        private EcommerceDbContext _context;

        public FormaEntregaQuery(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormaEntrega>> GetAll()
        {
            var lista = await _context.FormaEntrega.ToListAsync();
            return lista;
        }

        public async Task<FormaEntrega?> GetById(int id)
        {
            var element = await _context.FormaEntrega.Where(p => p.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
