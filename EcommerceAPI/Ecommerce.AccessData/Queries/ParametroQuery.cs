using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.AccessData.Queries
{
    public class ParametroQuery : IParametroQuery
    {
        private EcommerceDbContext _context;

        public ParametroQuery(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Parametro>> GetAll()
        {
            var lista = await _context.Parametro.ToListAsync();
            return lista;
        }

        public async Task<Parametro?> GetByKey(string clave)
        {
            var element = await _context.Parametro.Where(p => p.Clave == clave).FirstOrDefaultAsync();
            return element;
        }
    }
}
