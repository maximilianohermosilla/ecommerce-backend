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
    public class DireccionService : IDireccionService
    {
        private readonly IDireccionQuery _direccionQuery;
        private readonly IDireccionCommand _direccionCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<DireccionService> _logger;

        public DireccionService(IDireccionQuery direccionQuery, IDireccionCommand direccionCommand, IMapper mapper, ILogger<DireccionService> logger)
        {
            _direccionQuery = direccionQuery;
            _direccionCommand = direccionCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            DireccionResponse direccionResponse = new DireccionResponse();
            try
            {
                var estilo = await _direccionQuery.GetById(id);

                if (estilo == null)
                {
                    response.statusCode = 404;
                    response.message = "La direccion seleccionada no existe";
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

                await _direccionCommand.Delete(estilo);
                direccionResponse = _mapper.Map<DireccionResponse>(estilo);

                _logger.LogInformation("Se eliminó la direccion: " + id + ", " + estilo.Calle + " " + estilo.Numero);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{this.ToString()}.{LogHelper.Method()} - {ex.Message}");
            }

            response.statusCode = 200;
            response.message = "Direccion eliminada exitosamente";
            response.response = direccionResponse;
            return response;
        }

        public async Task<ResponseModel> GetAllByUser(int idUsuario)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Direccion> lista = await _direccionQuery.GetAllByUser(idUsuario);
                List<DireccionResponse> listaDTO = _mapper.Map<List<DireccionResponse>>(lista);
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
                Direccion direccion = await _direccionQuery.GetById(id);

                if (direccion == null)
                {
                    response.statusCode = 404;
                    response.message = "La direccion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                DireccionResponse direccionResponse = _mapper.Map<DireccionResponse>(direccion);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = direccionResponse;
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

        public async Task<ResponseModel> Insert(DireccionRequest element)
        {

            ResponseModel response = new ResponseModel();
            DireccionResponse direccionResponse = new DireccionResponse();
            try
            {
                Direccion direccion = _mapper.Map<Direccion>(element);
                direccion = await _direccionCommand.Insert(direccion);
                direccionResponse = _mapper.Map<DireccionResponse>(direccion);

                _logger.LogInformation("Se insertó una nueva direccion: " + JsonSerializer.Serialize(direccion));
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
            response.message = "Direccion insertada exitosamente";
            response.response = direccionResponse;
            return response;
        }

        public async Task<ResponseModel> Update(DireccionRequest element)
        {
            ResponseModel response = new ResponseModel();
            DireccionResponse direccionResponse = new DireccionResponse();
            try
            {
                var direccion = await _direccionQuery.GetById(element.Id);
                object direccionOld = JsonSerializer.Serialize(direccion);

                if (direccion == null)
                {
                    response.statusCode = 404;
                    response.message = "La direccion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                direccion.Calle = element.Calle;
                direccion.Numero = element.Numero;
                direccion.Piso = element.Piso;
                direccion.Departamento = element.Departamento;
                direccion.Provincia = element.Provincia;
                direccion.Localidad = element.Localidad;
                direccion.Municipio = element.Municipio;
                direccion.Observaciones = element.Observaciones;
                direccion.Habilitado = element.Habilitado;

                await _direccionCommand.Update(direccion);
                direccionResponse = _mapper.Map<DireccionResponse>(direccion);

                _logger.LogInformation("Se actualizó la direccion: " + direccion.Id + ". Antes: " + direccionOld + ". Despues: " + JsonSerializer.Serialize(direccion));
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
            response.message = "Direccion actualizada exitosamente";
            response.response = direccionResponse;
            return response;
        }
    }
}
