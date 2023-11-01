using AutoMapper;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Interfaces.IServices;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services
{
    public class CategoriaProductoService: ICategoriaProductoService
    {
        private readonly ICategoriaProductoQuery _categoriaProductoQuery;
        private readonly ICategoriaProductoCommand _categoriaProductoCommand;
        private readonly IMapper _mapper;

        public CategoriaProductoService(ICategoriaProductoQuery categoriaProductoQuery, ICategoriaProductoCommand categoriaProductoCommand, IMapper mapper)
        {
            _categoriaProductoQuery = categoriaProductoQuery;
            _categoriaProductoCommand = categoriaProductoCommand;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            CategoriaProductoResponse categoriaProductoResponse = new CategoriaProductoResponse();
            try
            {
                var estilo = await _categoriaProductoQuery.GetById(id);

                if (estilo == null)
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
                //    response.message = "No se puede eliminar el estilo porque posee al menos una cerveza asignada";
                //    response.response = null;
                //    return response;
                //}

                await _categoriaProductoCommand.Delete(estilo);
                categoriaProductoResponse = _mapper.Map<CategoriaProductoResponse>(estilo);

                //_logger.LogInformation("Se eliminó el estilo: " + id + ", " + estilo.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
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

                //_logger.LogInformation("Se insertó un nuevo categoriaProducto: " + categoriaProducto.Id + ". Nombre: " + categoriaProducto.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
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

                //_logger.LogInformation("Se actualizó la categoriaProducto: " + categoriaProducto.Id + ". Nombre anterior: " + categoriaProducto.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Categoria actualizada exitosamente";
            response.response = categoriaProductoResponse;
            return response;
        }
    }
}
