using AutoMapper;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Interfaces.IServices;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Services
{
    public class ParametroService: IParametroService
    {
        private readonly IParametroQuery _parametroQuery;
        private readonly IParametroCommand _parametroCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<ParametroService> _logger;

        public ParametroService(IParametroQuery parametroQuery, IParametroCommand parametroCommand, IMapper mapper, ILogger<ParametroService> logger)
        {
            _parametroQuery = parametroQuery;
            _parametroCommand = parametroCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            ParametroResponse parametroResponse = new ParametroResponse();
            try
            {
                var parametro = await _parametroQuery.GetById(id);

                if (parametro == null)
                {
                    response.statusCode = 404;
                    response.message = "El parametro seleccionado no existe";
                    response.response = null;
                    return response;
                }

                //List<Usuario> cervezas = await _usuarioService.GetAll(0, id, 0, 0, false);

                //if (cervezas.Any())
                //{
                //    response.statusCode = 409;
                //    response.message = "No se puede eliminar el parametro porque posee al menos una cerveza asignada";
                //    response.response = null;
                //    return response;
                //}

                await _parametroCommand.Delete(parametro);
                parametroResponse = _mapper.Map<ParametroResponse>(parametro);

                _logger.LogInformation("Se eliminó el parametro: " + id + ", Clave: " + parametro.Clave + ", Valor: " + parametro.Valor);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{this.ToString()}.{LogHelper.Method()} - {ex.Message}");
            }

            response.statusCode = 200;
            response.message = "Parametro eliminado exitosamente";
            response.response = parametroResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Parametro> lista = await _parametroQuery.GetAll();
                List<ParametroResponse> listaDTO = _mapper.Map<List<ParametroResponse>>(lista);

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

        public async Task<ResponseModel> GetByKey(string clave)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Parametro parametro = await _parametroQuery.GetByKey(clave);

                if (parametro == null)
                {
                    response.statusCode = 404;
                    response.message = "El parametro seleccionado no existe";
                    response.response = null;
                    return response;
                }

                ParametroResponse parametroResponse = _mapper.Map<ParametroResponse>(parametro);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = parametroResponse;
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

        public async Task<ResponseModel> Insert(ParametroRequest element)
        {

            ResponseModel response = new ResponseModel();
            ParametroResponse parametroResponse = new ParametroResponse();
            try
            {
                Parametro parametro = _mapper.Map<Parametro>(element);
                parametro = await _parametroCommand.Insert(parametro);
                parametroResponse = _mapper.Map<ParametroResponse>(parametro);

                _logger.LogInformation("Se insertó un nuevo parametro: " + parametro.Id + ". Clave: " + parametro.Clave + ", Valor: " + parametro.Valor);
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
            response.message = "Parametro insertado exitosamente";
            response.response = parametroResponse;
            return response;
        }

        public async Task<ResponseModel> Update(ParametroRequest element)
        {
            ResponseModel response = new ResponseModel();
            ParametroResponse parametroResponse = new ParametroResponse();
            try
            {
                var parametro = await _parametroQuery.GetByKey(element.Clave);

                if (parametro == null)
                {
                    response.statusCode = 404;
                    response.message = "El parametro seleccionado no existe";
                    response.response = null;
                    return response;
                }

                parametro.Clave = element.Clave;
                parametro.Valor = element.Valor;

                await _parametroCommand.Update(parametro);
                parametroResponse = _mapper.Map<ParametroResponse>(parametro);

                _logger.LogInformation("Se actualizó el parametro: " + parametro.Id + ". Valor anterior: " + parametro.Valor + ". Valor actual: " + element.Valor);
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
            response.message = "Parametro actualizado exitosamente";
            response.response = parametroResponse;
            return response;
        }
    }
}
