using AutoMapper;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Interfaces.IServices;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Services
{
    public class CategoriaProductoService: ICategoriaProductoService
    {
        private readonly ICategoriaProductoQuery _categoriaProductoQuery;
        private readonly ICategoriaProductoCommand _categoriaProductoCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriaProductoService> _logger;

        public CategoriaProductoService(ICategoriaProductoQuery categoriaProductoQuery, ICategoriaProductoCommand categoriaProductoCommand, IMapper mapper, ILogger<CategoriaProductoService> logger)
        {
            _categoriaProductoQuery = categoriaProductoQuery;
            _categoriaProductoCommand = categoriaProductoCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            CategoriaProductoResponse categoriaProductoResponse = new CategoriaProductoResponse();
            try
            {
                var categoria = await _categoriaProductoQuery.GetById(id);

                if (categoria == null)
                {
                    response.statusCode = 404;
                    response.message = "La categoria seleccionada no existe";
                    response.response = null;
                    return response;
                }

                //List<Usuario> cervezas = await _usuarioService.GetAll(0, id, 0, 0, false);

                //if (cervezas.Any())
                //{
                //    response.statusCode = 409;
                //    response.message = "No se puede eliminar el categoria porque posee al menos una cerveza asignada";
                //    response.response = null;
                //    return response;
                //}

                await _categoriaProductoCommand.Delete(categoria);
                categoriaProductoResponse = _mapper.Map<CategoriaProductoResponse>(categoria);

                _logger.LogInformation("Se eliminó la categoria: " + id + ", " + categoria.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{this.ToString()}.{LogHelper.Method()} - {ex.Message}");
            }

            response.statusCode = 200;
            response.message = "Categoria eliminada exitosamente";
            response.response = categoriaProductoResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<CategoriaProducto> lista = await _categoriaProductoQuery.GetAll();
                List<CategoriaProductoResponse> listaDTO = _mapper.Map<List<CategoriaProductoResponse>>(lista);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = listaDTO;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{this.ToString()}.{LogHelper.Method()} - {ex.Message}");
            }

            return response;
        }

        public async Task<ResponseModel> GetById(int id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                CategoriaProducto categoriaProducto = await _categoriaProductoQuery.GetById(id);

                if (categoriaProducto == null)
                {
                    response.statusCode = 404;
                    response.message = "La categoria seleccionada no existe";
                    response.response = null;
                    return response;
                }

                CategoriaProductoResponse categoriaProductoResponse = _mapper.Map<CategoriaProductoResponse>(categoriaProducto);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = categoriaProductoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{this.ToString()}.{LogHelper.Method()} - {ex.Message}");
            }

            return response;
        }

        public async Task<ResponseModel> Insert(CategoriaProductoRequest element)
        {

            ResponseModel response = new ResponseModel();
            CategoriaProductoResponse categoriaProductoResponse = new CategoriaProductoResponse();
            try
            {
                CategoriaProducto categoriaProducto = _mapper.Map<CategoriaProducto>(element);
                categoriaProducto = await _categoriaProductoCommand.Insert(categoriaProducto);
                categoriaProductoResponse = _mapper.Map<CategoriaProductoResponse>(categoriaProducto);

                _logger.LogInformation("Se insertó una nueva categoria: " + categoriaProducto.Id + ". Nombre: " + categoriaProducto.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{this.ToString()}.{LogHelper.Method()} - {ex.Message}");
                return response;
            }

            response.statusCode = 201;
            response.message = "Categoria insertada exitosamente";
            response.response = categoriaProductoResponse;
            return response;
        }

        public async Task<ResponseModel> Update(CategoriaProductoRequest element)
        {
            ResponseModel response = new ResponseModel();
            CategoriaProductoResponse categoriaProductoResponse = new CategoriaProductoResponse();
            try
            {
                var categoriaProducto = await _categoriaProductoQuery.GetById(element.Id);

                if (categoriaProducto == null)
                {
                    response.statusCode = 404;
                    response.message = "La categoria seleccionado no existe";
                    response.response = null;
                    return response;
                }

                categoriaProducto.Descripcion = element.Descripcion;
                categoriaProducto.Habilitado = element.Habilitado;

                await _categoriaProductoCommand.Update(categoriaProducto);
                categoriaProductoResponse = _mapper.Map<CategoriaProductoResponse>(categoriaProducto);

                _logger.LogInformation("Se actualizó la categoria: " + categoriaProducto.Id + ". Nombre anterior: " + categoriaProducto.Descripcion + ". Nombre actual: " + element.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{this.ToString()}.{LogHelper.Method()} - {ex.Message}");
                return response;
            }

            response.statusCode = 200;
            response.message = "Categoria actualizada exitosamente";
            response.response = categoriaProductoResponse;
            return response;
        }
    }
}
