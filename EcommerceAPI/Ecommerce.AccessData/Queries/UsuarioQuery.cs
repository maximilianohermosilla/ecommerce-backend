using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.AccessData.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private EcommerceDbContext _context;

        public UsuarioQuery(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAll(bool fullResponse)
        {
            if (fullResponse)
            {
                var listaFull = await _context.Usuario.Include(x => x.Direcciones).Include(x => x.Perfil).Include(x => x.Empresa).ToListAsync();
                return listaFull;
            }

            var lista = await _context.Usuario.ToListAsync();
            return lista;
        }

        public async Task<Usuario?> GetByEmail(string email)
        {
            var element = await _context.Usuario.Where(p => p.Email == email).FirstOrDefaultAsync();
            return element;
        }

        public async Task<Usuario?> GetById(int id, bool fullResponse)
        {
            if (fullResponse)
            {
                var elementFull = await _context.Usuario.Include(x => x.Direcciones).Include(x => x.Perfil).Include(x => x.Empresa).Where(p => p.Id == id).FirstOrDefaultAsync();
                return elementFull;
            }

            var element = await _context.Usuario.Where(p => p.Id == id).FirstOrDefaultAsync();
            return element;
        }

        public async Task<Usuario?> GetByUser(string user)
        {
            var element = await _context.Usuario.Where(p => p.User == user).FirstOrDefaultAsync();
            return element;
        }
    }
}
