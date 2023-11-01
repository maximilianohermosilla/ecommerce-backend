using Ecommerce.Application.Models;

namespace Ecommerce.Application.Interfaces.IServices
{
    public interface IEmpresaService
    { 
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Insert(EmpresaRequest element);
        Task<ResponseModel> Update(EmpresaRequest element);
        Task<ResponseModel> Delete(int id);
    }
}
