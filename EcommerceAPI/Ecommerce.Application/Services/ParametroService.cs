using AutoMapper;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Interfaces.IServices;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services
{
    public class ParametroService: IParametroService
    {
        private readonly IParametroQuery _parametroQuery;
        private readonly IParametroCommand _parametroCommand;
        private readonly IMapper _mapper;

        public ParametroService(IParametroQuery parametroQuery, IParametroCommand parametroCommand, IMapper mapper)
        {
            _parametroQuery = parametroQuery;
            _parametroCommand = parametroCommand;
            _mapper = mapper;            
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            ParametroResponse parametroResponse = new ParametroResponse();
            try
            {
                var estilo = await _parametroQuery.GetById(id);

                if (estilo == null)
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
                //    response.message = "No se puede eliminar el estilo porque posee al menos una cerveza asignada";
                //    response.response = null;
                //    return response;
                //}

                await _parametroCommand.Delete(estilo);
                parametroResponse = _mapper.Map<ParametroResponse>(estilo);

                //_logger.LogInformation("Se eliminó el estilo: " + id + ", " + estilo.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
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

                //_logger.LogInformation("Se insertó un nuevo parametro: " + parametro.Id + ". Nombre: " + parametro.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
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

                //_logger.LogInformation("Se actualizó el parametro: " + parametro.Id + ". Nombre anterior: " + parametro.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Parametro actualizado exitosamente";
            response.response = parametroResponse;
            return response;
        }
    }
}
