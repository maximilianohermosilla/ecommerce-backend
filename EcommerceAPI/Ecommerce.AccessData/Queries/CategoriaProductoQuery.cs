using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.AccessData.Queries
{
    public class CategoriaProductoQuery : ICategoriaProductoQuery
    {
        private EcommerceDbContext _context;

        public CategoriaProductoQuery(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaProducto>> GetAll()
        {
            var lista = await _context.CategoriaProducto.ToListAsync();
            return lista;
        }

        public async Task<CategoriaProducto?> GetById(int id)
        {
            var element = await _context.CategoriaProducto.Where(p => p.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
