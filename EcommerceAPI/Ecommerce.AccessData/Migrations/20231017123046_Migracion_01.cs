using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.AccessData.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promocion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cuotas = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoFormaPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFormaPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric(25,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    IdCategoriaProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_CategoriaProducto_IdCategoriaProducto",
                        column: x => x.IdCategoriaProducto,
                        principalTable: "CategoriaProducto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TipoCaracteristica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    IdCategoriaProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCaracteristica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoCaracteristica_CategoriaProducto_IdCategoriaProducto",
                        column: x => x.IdCategoriaProducto,
                        principalTable: "CategoriaProducto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    TelefonoPrincipal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TelefonoSecundario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PromocionCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    IdCategoriaProducto = table.Column<int>(type: "int", nullable: false),
                    IdPromocion = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocionCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromocionCategoria_CategoriaProducto_IdCategoriaProducto",
                        column: x => x.IdCategoriaProducto,
                        principalTable: "CategoriaProducto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromocionCategoria_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromocionCategoria_Promocion_IdPromocion",
                        column: x => x.IdPromocion,
                        principalTable: "Promocion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImagenProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreArchivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagenProducto_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductoDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric(25,2)", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoDetalle_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoDetalle_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PromocionProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdPromocion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocionProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromocionProducto_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromocionProducto_Promocion_IdPromocion",
                        column: x => x.IdPromocion,
                        principalTable: "Promocion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Caracteristica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoCaracteristica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caracteristica_TipoCaracteristica_IdTipoCaracteristica",
                        column: x => x.IdTipoCaracteristica,
                        principalTable: "TipoCaracteristica",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Piso = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direccion_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormaPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Expiracion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipoFormaPago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaPago_TipoFormaPago_IdTipoFormaPago",
                        column: x => x.IdTipoFormaPago,
                        principalTable: "TipoFormaPago",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormaPago_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Opinion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puntos = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinion_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opinion_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdProductoDetalle = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrito_ProductoDetalle_IdProductoDetalle",
                        column: x => x.IdProductoDetalle,
                        principalTable: "ProductoDetalle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carrito_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductoCaracteristica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProductoDetalle = table.Column<int>(type: "int", nullable: false),
                    IdCaracteristica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCaracteristica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoCaracteristica_Caracteristica_IdCaracteristica",
                        column: x => x.IdCaracteristica,
                        principalTable: "Caracteristica",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoCaracteristica_ProductoDetalle_IdProductoDetalle",
                        column: x => x.IdProductoDetalle,
                        principalTable: "ProductoDetalle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "numeric(25,2)", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdFormaEntrega = table.Column<int>(type: "int", nullable: false),
                    IdFormaPago = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdDireccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Direccion_IdDireccion",
                        column: x => x.IdDireccion,
                        principalTable: "Direccion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_Estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_FormaEntrega_IdFormaEntrega",
                        column: x => x.IdFormaEntrega,
                        principalTable: "FormaEntrega",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_FormaPago_IdFormaPago",
                        column: x => x.IdFormaPago,
                        principalTable: "FormaPago",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EstadoPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadoPedido_Estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstadoPedido_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Descuento = table.Column<float>(type: "real", nullable: false),
                    PrecioFinal = table.Column<float>(type: "real", nullable: false),
                    IdProductoDetalle = table.Column<int>(type: "int", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoDetalle_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidoDetalle_ProductoDetalle_IdProductoDetalle",
                        column: x => x.IdProductoDetalle,
                        principalTable: "ProductoDetalle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caracteristica_IdTipoCaracteristica",
                table: "Caracteristica",
                column: "IdTipoCaracteristica");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdProductoDetalle",
                table: "Carrito",
                column: "IdProductoDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdUsuario",
                table: "Carrito",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_IdUsuario",
                table: "Direccion",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoPedido_IdEstado",
                table: "EstadoPedido",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoPedido_IdPedido",
                table: "EstadoPedido",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPago_IdTipoFormaPago",
                table: "FormaPago",
                column: "IdTipoFormaPago");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPago_IdUsuario",
                table: "FormaPago",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenProducto_IdProducto",
                table: "ImagenProducto",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Opinion_IdProducto",
                table: "Opinion",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Opinion_IdUsuario",
                table: "Opinion",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdDireccion",
                table: "Pedido",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdEstado",
                table: "Pedido",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdFormaEntrega",
                table: "Pedido",
                column: "IdFormaEntrega");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdFormaPago",
                table: "Pedido",
                column: "IdFormaPago");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdUsuario",
                table: "Pedido",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_IdPedido",
                table: "PedidoDetalle",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_IdProductoDetalle",
                table: "PedidoDetalle",
                column: "IdProductoDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoriaProducto",
                table: "Producto",
                column: "IdCategoriaProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCaracteristica_IdCaracteristica",
                table: "ProductoCaracteristica",
                column: "IdCaracteristica");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCaracteristica_IdProductoDetalle",
                table: "ProductoCaracteristica",
                column: "IdProductoDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoDetalle_IdEmpresa",
                table: "ProductoDetalle",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoDetalle_IdProducto",
                table: "ProductoDetalle",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionCategoria_IdCategoriaProducto",
                table: "PromocionCategoria",
                column: "IdCategoriaProducto");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionCategoria_IdEmpresa",
                table: "PromocionCategoria",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionCategoria_IdPromocion",
                table: "PromocionCategoria",
                column: "IdPromocion");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionProducto_IdProducto",
                table: "PromocionProducto",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionProducto_IdPromocion",
                table: "PromocionProducto",
                column: "IdPromocion");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCaracteristica_IdCategoriaProducto",
                table: "TipoCaracteristica",
                column: "IdCategoriaProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdEmpresa",
                table: "Usuario",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario",
                column: "IdPerfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "EstadoPedido");

            migrationBuilder.DropTable(
                name: "ImagenProducto");

            migrationBuilder.DropTable(
                name: "Opinion");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "PedidoDetalle");

            migrationBuilder.DropTable(
                name: "ProductoCaracteristica");

            migrationBuilder.DropTable(
                name: "PromocionCategoria");

            migrationBuilder.DropTable(
                name: "PromocionProducto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Caracteristica");

            migrationBuilder.DropTable(
                name: "ProductoDetalle");

            migrationBuilder.DropTable(
                name: "Promocion");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "FormaPago");

            migrationBuilder.DropTable(
                name: "TipoCaracteristica");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "TipoFormaPago");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "CategoriaProducto");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
