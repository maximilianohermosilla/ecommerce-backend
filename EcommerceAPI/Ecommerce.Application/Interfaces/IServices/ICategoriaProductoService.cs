using Ecommerce.Application.Models;

namespace Ecommerce.Application.Interfaces.IServices
{
    public interface ICategoriaProductoService
    { 
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Insert(CategoriaProductoRequest element);
        Task<ResponseModel> Update(CategoriaProductoRequest element);
        Task<ResponseModel> Delete(int id);
    }
}
