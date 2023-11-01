using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.AccessData.Queries
{
    public class EstadoQuery : IEstadoQuery
    {
        private EcommerceDbContext _context;

        public EstadoQuery(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estado>> GetAll()
        {
            var lista = await _context.Estado.ToListAsync();
            return lista;
        }

        public async Task<Estado?> GetById(int id)
        {
            var element = await _context.Estado.Where(p => p.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
