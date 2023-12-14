using Ecommerce.Application.Models;

namespace Ecommerce.Application.Interfaces.IServices
{
    public interface IDireccionService
    { 
        Task<ResponseModel> GetAllByUser(int idUsuario);
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Insert(DireccionRequest element);
        Task<ResponseModel> Update(DireccionRequest element);
        Task<ResponseModel> Delete(int id);
    }
}
