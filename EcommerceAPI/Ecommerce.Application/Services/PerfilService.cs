using AutoMapper;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Interfaces.IServices;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Ecommerce.Application.Services
{
    public class PerfilService: IPerfilService
    {
        private readonly IPerfilQuery _perfilQuery;
        private readonly IPerfilCommand _perfilCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<PerfilService> _logger;

        public PerfilService(IPerfilQuery perfilQuery, IPerfilCommand perfilCommand, IMapper mapper, ILogger<PerfilService> logger)
        {
            _perfilQuery = perfilQuery;
            _perfilCommand = perfilCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            PerfilResponse perfilResponse = new PerfilResponse();
            try
            {
                var perfil = await _perfilQuery.GetById(id);

                if (perfil == null)
                {
                    response.statusCode = 404;
                    response.message = "El perfil seleccionado no existe";
                    response.response = null;
                    return response;
                }

                //List<Usuario> cervezas = await _usuarioService.GetAll(0, id, 0, 0, false);

                //if (cervezas.Any())
                //{
                //    response.statusCode = 409;
                //    response.message = "No se puede eliminar el perfil porque posee al menos una cerveza asignada";
                //    response.response = null;
                //    return response;
                //}

                await _perfilCommand.Delete(perfil);
                perfilResponse = _mapper.Map<PerfilResponse>(perfil);

                _logger.LogInformation("Se eliminó el perfil: " + id + ", " + perfil.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{this.ToString()}.{LogHelper.Method()} - {ex.Message}");
            }

            response.statusCode = 200;
            response.message = "Perfil eliminado exitosamente";
            response.response = perfilResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Perfil> lista = await _perfilQuery.GetAll();
                List<PerfilResponse> listaDTO = _mapper.Map<List<PerfilResponse>>(lista);

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
                Perfil perfil = await _perfilQuery.GetById(id);

                if (perfil == null)
                {
                    response.statusCode = 404;
                    response.message = "El perfil seleccionado no existe";
                    response.response = null;
                    return response;
                }

                PerfilResponse perfilResponse = _mapper.Map<PerfilResponse>(perfil);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = perfilResponse;
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

        public async Task<ResponseModel> Insert(PerfilRequest element)
        {

            ResponseModel response = new ResponseModel();
            PerfilResponse perfilResponse = new PerfilResponse();
            try
            {
                Perfil perfil = _mapper.Map<Perfil>(element);
                perfil = await _perfilCommand.Insert(perfil);
                perfilResponse = _mapper.Map<PerfilResponse>(perfil);

                _logger.LogInformation("Se insertó un nuevo perfil: " + perfil.Id + ". Nombre: " + perfil.Descripcion);
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
            response.message = "Perfil insertado exitosamente";
            response.response = perfilResponse;
            return response;
        }

        public async Task<ResponseModel> Update(PerfilRequest element)
        {
            ResponseModel response = new ResponseModel();
            PerfilResponse perfilResponse = new PerfilResponse();
            try
            {
                var perfil = await _perfilQuery.GetById(element.Id);
                string perfilOld = JsonSerializer.Serialize(perfil);

                if (perfil == null)
                {
                    response.statusCode = 404;
                    response.message = "El perfil seleccionado no existe";
                    response.response = null;
                    return response;
                }

                perfil.Descripcion = element.Descripcion;
                perfil.Habilitado = element.Habilitado;

                await _perfilCommand.Update(perfil);
                perfilResponse = _mapper.Map<PerfilResponse>(perfil);

                _logger.LogInformation("Se actualizó el perfil: " + perfil.Id + ". Anterior: " + perfilOld + ". Actual: " + JsonSerializer.Serialize(perfil));
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
            response.message = "Perfil actualizado exitosamente";
            response.response = perfilResponse;
            return response;
        }
    }
}
