using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.AccessData.Queries
{
    public class EmpresaQuery : IEmpresaQuery
    {
        private EcommerceDbContext _context;

        public EmpresaQuery(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empresa>> GetAll()
        {
            var lista = await _context.Empresa.ToListAsync();
            return lista;
        }

        public async Task<Empresa?> GetById(int id)
        {
            var element = await _context.Empresa.Where(p => p.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
