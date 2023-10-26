using AutoMapper;
using Ecommerce.Application.Models;
using Ecommerce.Domain.Entities;

namespace EcommerceAPI.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CaracteristicaRequest, Caracteristica>().ReverseMap();
            CreateMap<CaracteristicaResponse, Caracteristica>().ReverseMap();

            CreateMap<CarritoRequest, Carrito>().ReverseMap();
            CreateMap<CarritoResponse, Carrito>().ReverseMap();

            CreateMap<CarritoResponse, Carrito>().ReverseMap();

            CreateMap<CategoriaProductoRequest, CategoriaProducto>().ReverseMap();
            CreateMap<CategoriaProductoResponse, CategoriaProducto>().ReverseMap();

            CreateMap<DireccionRequest, Direccion>().ReverseMap();
            CreateMap<DireccionResponse, Direccion>().ReverseMap();

            CreateMap<EmpresaRequest, Empresa>().ReverseMap();
            CreateMap<EmpresaResponse, Empresa>().ReverseMap();

            CreateMap<EstadoPedidoRequest, EstadoPedido>().ReverseMap();
            CreateMap<EstadoPedidoResponse, EstadoPedido>().ReverseMap();

            CreateMap<EstadoRequest, Estado>().ReverseMap();
            CreateMap<EstadoResponse, Estado>().ReverseMap();

            CreateMap<FormaEntregaRequest, FormaEntrega>().ReverseMap();
            CreateMap<FormaEntregaResponse, FormaEntrega>().ReverseMap();

            CreateMap<FormaPagoRequest, FormaPago>().ReverseMap();
            CreateMap<FormaPagoResponse, FormaPago>().ReverseMap();

            CreateMap<ImagenProductoRequest, ImagenProducto>().ReverseMap();
            CreateMap<ImagenProductoResponse, ImagenProducto>().ReverseMap();

            CreateMap<OpinionRequest, Opinion>().ReverseMap();
            CreateMap<OpinionResponse, Opinion>().ReverseMap();

            CreateMap<ParametroRequest, Parametro>().ReverseMap();
            CreateMap<ParametroResponse, Parametro>().ReverseMap();

            CreateMap<PedidoDetalleRequest, PedidoDetalle>().ReverseMap();
            CreateMap<PedidoDetalleResponse, PedidoDetalle>().ReverseMap();

            CreateMap<PedidoRequest, Pedido>().ReverseMap();
            CreateMap<PedidoResponse, Pedido>().ReverseMap();

            CreateMap<PerfilRequest, Perfil>().ReverseMap();
            CreateMap<PerfilResponse, Perfil>().ReverseMap();

            CreateMap<ProductoCaracteristicaRequest, ProductoCaracteristica>().ReverseMap();
            CreateMap<ProductoCaracteristicaResponse, ProductoCaracteristica>().ReverseMap();

            CreateMap<ProductoDetalleRequest, ProductoDetalle>().ReverseMap();
            CreateMap<ProductoDetalleResponse, ProductoDetalle>().ReverseMap();
            
            CreateMap<ProductoPedidoDetalleResponse, ProductoDetalle>().ReverseMap();

            CreateMap<ProductoPedidoResponse, Producto>().ReverseMap();

            CreateMap<ProductoRequest, Producto>().ReverseMap();
            CreateMap<ProductoResponse, Producto>().ReverseMap();

            CreateMap<PromocionCategoriaRequest, PromocionCategoria>().ReverseMap();
            CreateMap<PromocionCategoriaResponse, PromocionCategoria>().ReverseMap();

            CreateMap<PromocionProductoRequest, PromocionProducto>().ReverseMap();
            CreateMap<PromocionProductoResponse, PromocionProducto>().ReverseMap();

            CreateMap<PromocionRequest, Promocion>().ReverseMap();
            CreateMap<PromocionResponse, Promocion>().ReverseMap();

            CreateMap<TipoCaracteristicaRequest, TipoCaracteristica>().ReverseMap();
            CreateMap<TipoCaracteristicaResponse, TipoCaracteristica>().ReverseMap();

            CreateMap<TipoFormaPagoRequest, TipoFormaPago>().ReverseMap();
            CreateMap<TipoFormaPagoResponse, TipoFormaPago>().ReverseMap();
                        
            CreateMap<UsuarioGetResponse, Usuario>().ReverseMap();

            CreateMap<UsuarioRequest, Usuario>().ReverseMap();
            CreateMap<UsuarioResponse, Usuario>().ReverseMap();
        }
    }
}
