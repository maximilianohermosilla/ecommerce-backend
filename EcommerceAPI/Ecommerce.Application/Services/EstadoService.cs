using AutoMapper;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Interfaces.IServices;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services
{
    public class EstadoService: IEstadoService
    {
        private readonly IEstadoQuery _estadoQuery;
        private readonly IEstadoCommand _estadoCommand;
        private readonly IMapper _mapper;

        public EstadoService(IEstadoQuery estadoQuery, IEstadoCommand estadoCommand, IMapper mapper)
        {
            _estadoQuery = estadoQuery;
            _estadoCommand = estadoCommand;
            _mapper = mapper;            
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            EstadoResponse estadoResponse = new EstadoResponse();
            try
            {
                var estilo = await _estadoQuery.GetById(id);

                if (estilo == null)
                {
                    response.statusCode = 404;
                    response.message = "El estado seleccionado no existe";
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

                await _estadoCommand.Delete(estilo);
                estadoResponse = _mapper.Map<EstadoResponse>(estilo);

                //_logger.LogInformation("Se eliminó el estilo: " + id + ", " + estilo.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Estado eliminado exitosamente";
            response.response = estadoResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Estado> lista = await _estadoQuery.GetAll();
                List<EstadoResponse> listaDTO = _mapper.Map<List<EstadoResponse>>(lista);

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
                Estado estado = await _estadoQuery.GetById(id);

                if (estado == null)
                {
                    response.statusCode = 404;
                    response.message = "El estado seleccionado no existe";
                    response.response = null;
                    return response;
                }

                EstadoResponse estadoResponse = _mapper.Map<EstadoResponse>(estado);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = estadoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(EstadoRequest element)
        {

            ResponseModel response = new ResponseModel();
            EstadoResponse estadoResponse = new EstadoResponse();
            try
            {
                Estado estado = _mapper.Map<Estado>(element);
                estado = await _estadoCommand.Insert(estado);
                estadoResponse = _mapper.Map<EstadoResponse>(estado);

                //_logger.LogInformation("Se insertó un nuevo estado: " + estado.Id + ". Nombre: " + estado.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Estado insertado exitosamente";
            response.response = estadoResponse;
            return response;
        }

        public async Task<ResponseModel> Update(EstadoRequest element)
        {
            ResponseModel response = new ResponseModel();
            EstadoResponse estadoResponse = new EstadoResponse();
            try
            {
                var estado = await _estadoQuery.GetById(element.Id);

                if (estado == null)
                {
                    response.statusCode = 404;
                    response.message = "El estado seleccionado no existe";
                    response.response = null;
                    return response;
                }

                estado.Descripcion = element.Descripcion;

                await _estadoCommand.Update(estado);
                estadoResponse = _mapper.Map<EstadoResponse>(estado);

                //_logger.LogInformation("Se actualizó el estado: " + estado.Id + ". Nombre anterior: " + estado.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Estado actualizado exitosamente";
            response.response = estadoResponse;
            return response;
        }
    }
}
