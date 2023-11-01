﻿using Ecommerce.Application.Models;

namespace Ecommerce.Application.Interfaces.IServices
{
    public interface IPerfilService
    { 
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Insert(PerfilRequest element);
        Task<ResponseModel> Update(PerfilRequest element);
        Task<ResponseModel> Delete(int id);
    }
}
