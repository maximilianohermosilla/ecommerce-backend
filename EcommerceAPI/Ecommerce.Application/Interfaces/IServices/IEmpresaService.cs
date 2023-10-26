using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.IQueries
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
