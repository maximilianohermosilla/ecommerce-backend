using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.AccessData.Queries
{
    public class DireccionQuery : IDireccionQuery
    {
        private EcommerceDbContext _context;

        public DireccionQuery(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Direccion>> GetAllByUser(int idUsuario)
        {
            var lista = await _context.Direccion.Where(x => x.IdUsuario == idUsuario).OrderByDescending(x => x.Principal).ToListAsync();
            return lista;
        }

        public async Task<Direccion?> GetById(int id)
        {
            var element = await _context.Direccion.Where(p => p.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
