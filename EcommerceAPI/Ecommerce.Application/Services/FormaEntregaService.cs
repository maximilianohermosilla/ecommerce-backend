using AutoMapper;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Interfaces.IServices;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services
{
    public class FormaEntregaService: IFormaEntregaService
    {
        private readonly IFormaEntregaQuery _formaDeEntregaQuery;
        private readonly IFormaEntregaCommand _formaDeEntregaCommand;
        private readonly IMapper _mapper;

        public FormaEntregaService(IFormaEntregaQuery formaDeEntregaQuery, IFormaEntregaCommand formaDeEntregaCommand, IMapper mapper)
        {
            _formaDeEntregaQuery = formaDeEntregaQuery;
            _formaDeEntregaCommand = formaDeEntregaCommand;
            _mapper = mapper;
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

                //_logger.LogInformation("Se eliminó el estilo: " + id + ", " + estilo.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
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

                //_logger.LogInformation("Se insertó un nuevo formaDeEntrega: " + formaDeEntrega.Id + ". Nombre: " + formaDeEntrega.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
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

                //_logger.LogInformation("Se actualizó la formaDeEntrega: " + formaDeEntrega.Id + ". Nombre anterior: " + formaDeEntrega.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Forma de entrega actualizada exitosamente";
            response.response = formaDeEntregaResponse;
            return response;
        }
    }
}
