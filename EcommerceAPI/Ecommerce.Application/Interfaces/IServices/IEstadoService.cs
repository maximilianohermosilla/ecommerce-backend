using Ecommerce.Application.Models;

namespace Ecommerce.Application.Interfaces.IServices
{
    public interface IEstadoService
    { 
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Insert(EstadoRequest element);
        Task<ResponseModel> Update(EstadoRequest element);
        Task<ResponseModel> Delete(int id);
    }
}
