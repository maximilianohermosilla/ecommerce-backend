using Ecommerce.Application.Models;

namespace Ecommerce.Application.Interfaces.IServices
{
    public interface IParametroService
    { 
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetByKey(string clave);
        Task<ResponseModel> Insert(ParametroRequest element);
        Task<ResponseModel> Update(ParametroRequest element);
        Task<ResponseModel> Delete(int id);
    }
}
