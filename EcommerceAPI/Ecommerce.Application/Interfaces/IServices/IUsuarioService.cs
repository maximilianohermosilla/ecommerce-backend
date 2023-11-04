using Ecommerce.Application.Models;

namespace Ecommerce.Application.Interfaces.IServices
{
    public interface IUsuarioService
    { 
        Task<ResponseModel> GetAll(bool fullResponse);
        Task<ResponseModel> GetById(int id, bool fullResponse);
        Task<ResponseModel> GetByUser(string user);
        Task<ResponseModel> GetByEmail(string email);
        Task<ResponseModel> Insert(UsuarioRequest element);
        Task<ResponseModel> Update(UsuarioRequest element);
    }
}
