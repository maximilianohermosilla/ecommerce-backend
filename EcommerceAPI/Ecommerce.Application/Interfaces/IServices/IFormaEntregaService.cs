using Ecommerce.Application.Models;

namespace Ecommerce.Application.Interfaces.IServices
{
    public interface IFormaEntregaService
    { 
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Insert(FormaEntregaRequest element);
        Task<ResponseModel> Update(FormaEntregaRequest element);
        Task<ResponseModel> Delete(int id);
    }
}
