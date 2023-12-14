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
    public class FormaEntregaService: IFormaEntregaService
    {
        private readonly IFormaEntregaQuery _formaDeEntregaQuery;
        private readonly IFormaEntregaCommand _formaDeEntregaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<FormaEntregaService> _logger;

        public FormaEntregaService(IFormaEntregaQuery formaDeEntregaQuery, IFormaEntregaCommand formaDeEntregaCommand, IMapper mapper, ILogger<FormaEntregaService> logger)
        {
            _formaDeEntregaQuery = formaDeEntregaQuery;
            _formaDeEntregaCommand = formaDeEntregaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            FormaEntregaResponse formaDeEntregaResponse = new FormaEntregaResponse();
            try
            {
                var estilo = await _formaDeEntregaQuery.GetById(id);

                if (estilo == null)
                {
                    response.statusCode = 404;
                    response.message = "La forma de entrega seleccionada no existe";
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

                await _formaDeEntregaCommand.Delete(estilo);
                formaDeEntregaResponse = _mapper.Map<FormaEntregaResponse>(estilo);

                _logger.LogInformation("Se eliminó la forma de entrega: " + id + ", " + estilo.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{this.ToString()}.{LogHelper.Method()} - {ex.Message}");
            }

            response.statusCode = 200;
            response.message = "Forma de entrega eliminada exitosamente";
            response.response = formaDeEntregaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<FormaEntrega> lista = await _formaDeEntregaQuery.GetAll();
                List<FormaEntregaResponse> listaDTO = _mapper.Map<List<FormaEntregaResponse>>(lista);

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
                FormaEntrega formaDeEntrega = await _formaDeEntregaQuery.GetById(id);

                if (formaDeEntrega == null)
                {
                    response.statusCode = 404;
                    response.message = "La forma de entrega seleccionada no existe";
                    response.response = null;
                    return response;
                }

                FormaEntregaResponse formaDeEntregaResponse = _mapper.Map<FormaEntregaResponse>(formaDeEntrega);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = formaDeEntregaResponse;
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

        public async Task<ResponseModel> Insert(FormaEntregaRequest element)
        {

            ResponseModel response = new ResponseModel();
            FormaEntregaResponse formaDeEntregaResponse = new FormaEntregaResponse();
            try
            {
                FormaEntrega formaDeEntrega = _mapper.Map<FormaEntrega>(element);
                formaDeEntrega = await _formaDeEntregaCommand.Insert(formaDeEntrega);
                formaDeEntregaResponse = _mapper.Map<FormaEntregaResponse>(formaDeEntrega);

                _logger.LogInformation("Se insertó una nueva forma de entrega: " + formaDeEntrega.Id + ". Nombre: " + formaDeEntrega.Descripcion);
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
            response.message = "Forma de entrega insertada exitosamente";
            response.response = formaDeEntregaResponse;
            return response;
        }

        public async Task<ResponseModel> Update(FormaEntregaRequest element)
        {
            ResponseModel response = new ResponseModel();
            FormaEntregaResponse formaDeEntregaResponse = new FormaEntregaResponse();
            try
            {
                var formaDeEntrega = await _formaDeEntregaQuery.GetById(element.Id);
                string formaDeEntregaOld = JsonSerializer.Serialize(formaDeEntrega);


                if (formaDeEntrega == null)
                {
                    response.statusCode = 404;
                    response.message = "La forma de entrega seleccionado no existe";
                    response.response = null;
                    return response;
                }

                formaDeEntrega.Descripcion = element.Descripcion;

                await _formaDeEntregaCommand.Update(formaDeEntrega);
                formaDeEntregaResponse = _mapper.Map<FormaEntregaResponse>(formaDeEntrega);

                _logger.LogInformation("Se actualizó la forma de entrega: " + formaDeEntrega.Id + ". Anterior: " + formaDeEntregaOld + ". Actual: " + JsonSerializer.Serialize(formaDeEntrega));
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
            response.message = "Forma de entrega actualizada exitosamente";
            response.response = formaDeEntregaResponse;
            return response;
        }
    }
}
