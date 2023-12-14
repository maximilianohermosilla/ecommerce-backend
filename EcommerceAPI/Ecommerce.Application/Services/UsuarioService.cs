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
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IUsuarioCommand _usuarioCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUsuarioQuery usuarioQuery, IUsuarioCommand usuarioCommand, IMapper mapper, ILogger<UsuarioService> logger)
        {
            _usuarioQuery = usuarioQuery;
            _usuarioCommand = usuarioCommand;
            _mapper = mapper;            
            _logger = logger;
        }

        public async Task<ResponseModel> GetAll(bool fullResponse)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Usuario> lista = await _usuarioQuery.GetAll(fullResponse);
                List<UsuarioGetResponse> listaDTO = _mapper.Map<List<UsuarioGetResponse>>(lista);

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

        public async Task<ResponseModel> GetById(int id, bool fullResponse)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Usuario usuario = await _usuarioQuery.GetById(id, fullResponse);

                if (usuario == null)
                {
                    response.statusCode = 404;
                    response.message = "El usuario seleccionado no existe";
                    response.response = null;
                    return response;
                }

                
                UsuarioGetResponse usuarioResponse = _mapper.Map<UsuarioGetResponse>(usuario);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = usuarioResponse;
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

        public async Task<ResponseModel> Insert(UsuarioRequest element)
        {

            ResponseModel response = new ResponseModel();
            UsuarioResponse usuarioResponse = new UsuarioResponse();
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(element);
                usuario = await _usuarioCommand.Insert(usuario);
                usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

                _logger.LogInformation("Se insertó un nuevo usuario: " + usuario.Id + ". Nombre: " + usuario.User);
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
            response.message = "Usuario insertado exitosamente";
            response.response = usuarioResponse;
            return response;
        }

        public async Task<ResponseModel> Update(UsuarioRequest element)
        {
            ResponseModel response = new ResponseModel();
            UsuarioResponse usuarioResponse = new UsuarioResponse();
            try
            {
                var usuario = await _usuarioQuery.GetById(element.Id, false);
                string usuarioOld = JsonSerializer.Serialize(usuario);

                if (usuario == null)
                {
                    response.statusCode = 404;
                    response.message = "El usuario seleccionado no existe";
                    response.response = null;
                    return response;
                }

                usuario.Nombre = element.Nombre;

                await _usuarioCommand.Update(usuario);
                usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

                _logger.LogInformation("Se actualizó el usuario: " + usuario.Id + ". Anterior: " + usuarioOld + ". Actual: " + JsonSerializer.Serialize(usuario));
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
            response.message = "Usuario actualizado exitosamente";
            response.response = usuarioResponse;
            return response;
        }

        public async Task<ResponseModel> GetByEmail(string email)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Usuario usuario = await _usuarioQuery.GetByEmail(email);

                if (usuario == null)
                {
                    response.statusCode = 404;
                    response.message = "El usuario seleccionado no existe";
                    response.response = null;
                    return response;
                }

                UsuarioResponse usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = usuarioResponse;
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

        public async Task<ResponseModel> GetByUser(string user)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Usuario usuario = await _usuarioQuery.GetByUser(user);

                if (usuario == null)
                {
                    response.statusCode = 404;
                    response.message = "El usuario seleccionado no existe";
                    response.response = null;
                    return response;
                }

                UsuarioResponse usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = usuarioResponse;
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
    }
}
