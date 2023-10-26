using AutoMapper;
using Ecommerce.Application.Interfaces.ICommands;
using Ecommerce.Application.Interfaces.IQueries;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services
{
    public class EmpresaService: IEmpresaService
    {
        private readonly IEmpresaQuery _empresaQuery;
        private readonly IEmpresaCommand _empresaCommand;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaQuery empresaQuery, IEmpresaCommand empresaCommand, IMapper mapper)
        {
            _empresaQuery = empresaQuery;
            _empresaCommand = empresaCommand;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            EmpresaResponse empresaResponse = new EmpresaResponse();
            try
            {
                var estilo = await _empresaQuery.GetById(id);

                if (estilo == null)
                {
                    response.statusCode = 404;
                    response.message = "La empresa seleccionada no existe";
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

                await _empresaCommand.Delete(estilo);
                empresaResponse = _mapper.Map<EmpresaResponse>(estilo);

                //_logger.LogInformation("Se eliminó el estilo: " + id + ", " + estilo.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Empresa eliminada exitosamente";
            response.response = empresaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Empresa> lista = await _empresaQuery.GetAll();
                List<EmpresaResponse> listaDTO = _mapper.Map<List<EmpresaResponse>>(lista);

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
                Empresa empresa = await _empresaQuery.GetById(id);

                if (empresa == null)
                {
                    response.statusCode = 404;
                    response.message = "La empresa seleccionada no existe";
                    response.response = null;
                    return response;
                }

                EmpresaResponse empresaResponse = _mapper.Map<EmpresaResponse>(empresa);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = empresaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(EmpresaRequest element)
        {

            ResponseModel response = new ResponseModel();
            EmpresaResponse empresaResponse = new EmpresaResponse();
            try
            {
                Empresa empresa = _mapper.Map<Empresa>(element);
                empresa = await _empresaCommand.Insert(empresa);
                empresaResponse = _mapper.Map<EmpresaResponse>(empresa);

                //_logger.LogInformation("Se insertó un nuevo empresa: " + empresa.Id + ". Nombre: " + empresa.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Empresa insertada exitosamente";
            response.response = empresaResponse;
            return response;
        }

        public async Task<ResponseModel> Update(EmpresaRequest element)
        {
            ResponseModel response = new ResponseModel();
            EmpresaResponse empresaResponse = new EmpresaResponse();
            try
            {
                var empresa = await _empresaQuery.GetById(element.Id);

                if (empresa == null)
                {
                    response.statusCode = 404;
                    response.message = "La empresa seleccionado no existe";
                    response.response = null;
                    return response;
                }

                empresa.Descripcion = element.Descripcion;
                empresa.Habilitado = element.Habilitado;

                await _empresaCommand.Update(empresa);
                empresaResponse = _mapper.Map<EmpresaResponse>(empresa);

                //_logger.LogInformation("Se actualizó la empresa: " + empresa.Id + ". Nombre anterior: " + empresa.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Empresa actualizada exitosamente";
            response.response = empresaResponse;
            return response;
        }
    }
}
