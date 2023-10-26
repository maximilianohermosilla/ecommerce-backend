using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.AccessData.Queries
{
    public class PerfilQuery : IPerfilQuery
    {
        private EcommerceDbContext _context;

        public PerfilQuery(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Perfil>> GetAll()
        {
            var lista = await _context.Perfil.ToListAsync();
            return lista;
        }

        public async Task<Perfil?> GetById(int id)
        {
            var element = await _context.Perfil.Where(p => p.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
