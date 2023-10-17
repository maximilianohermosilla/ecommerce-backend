using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ecommerce.AccessData
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
        {
        }

        public DbSet<Caracteristica> Caracteristica { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<EstadoPedido> EstadoPedido { get; set; }
        public DbSet<FormaEntrega> FormaEntrega { get; set; }
        public DbSet<FormaPago> FormaPago { get; set; }
        public DbSet<ImagenProducto> ImagenProducto { get; set; }
        public DbSet<Opinion> Opinion { get; set; }
        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalle { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoCaracteristica> ProductoCaracteristica { get; set; }
        public DbSet<ProductoDetalle> ProductoDetalle { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<PromocionCategoria> PromocionCategoria { get; set; }
        public DbSet<PromocionProducto> PromocionProducto { get; set; }
        public DbSet<TipoCaracteristica> TipoCaracteristica { get; set; }
        public DbSet<TipoFormaPago> TipoFormaPago { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost; Database=Ecommerce; Trusted_Connection=True; TrustServerCertificate=True");
        //    //optionsBuilder.UseSqlServer("Server=SQL5097.site4now.net;Database=Ecommerce;User Id=db_a934ba_mayibeercollection_admin;Password=Caslacapo1908**");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caracteristica>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100).IsRequired();
                entity.HasOne(d => d.TipoCaracteristica).WithMany(p => p.Caracteristicas).HasForeignKey(d => d.IdTipoCaracteristica);
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasOne(d => d.ProductoDetalle).WithMany(p => p.Carritos).HasForeignKey(d => d.IdProductoDetalle);
                entity.HasOne(d => d.Usuario).WithMany(p => p.Carritos).HasForeignKey(d => d.IdUsuario);
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.Property(e => e.Calle).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Numero).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Piso).HasMaxLength(25);
                entity.Property(e => e.Departamento).HasMaxLength(25);
                entity.Property(e => e.Pais).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Provincia).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Localidad).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Municipio).HasMaxLength(100).IsRequired();
                entity.HasOne(d => d.Usuario).WithMany(p => p.Direcciones).HasForeignKey(d => d.IdUsuario);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<EstadoPedido>(entity =>
            {
                entity.HasOne(d => d.Estado).WithMany(p => p.EstadoPedidos).HasForeignKey(d => d.IdEstado);
                entity.HasOne(d => d.Pedido).WithMany(p => p.EstadoPedidos).HasForeignKey(d => d.IdPedido);
            });

            modelBuilder.Entity<FormaEntrega>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.Property(e => e.Entidad).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Numero).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Expiracion).HasMaxLength(5).IsRequired();
                entity.HasOne(d => d.Usuario).WithMany(p => p.FormaPagos).HasForeignKey(d => d.IdUsuario);
                entity.HasOne(d => d.TipoFormaPago).WithMany(p => p.FormaPagos).HasForeignKey(d => d.IdTipoFormaPago);
            });

            modelBuilder.Entity<ImagenProducto>(entity =>
            {
                entity.Property(e => e.NombreArchivo).HasMaxLength(250);                
                entity.HasOne(d => d.Producto).WithMany(p => p.ImagenProductos).HasForeignKey(d => d.IdProducto);
            });

            modelBuilder.Entity<Opinion>(entity =>
            {
                entity.HasOne(d => d.Usuario).WithMany(p => p.Opiniones).HasForeignKey(d => d.IdUsuario);
                entity.HasOne(d => d.Producto).WithMany(p => p.Opiniones).HasForeignKey(d => d.IdProducto);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.PrecioTotal).HasColumnType("numeric(25,2)");
                entity.HasOne(d => d.Estado).WithMany(p => p.Pedidos).HasForeignKey(d => d.IdEstado);
                entity.HasOne(d => d.FormaEntrega).WithMany(p => p.Pedidos).HasForeignKey(d => d.IdFormaEntrega);
                entity.HasOne(d => d.FormaPago).WithMany(p => p.Pedidos).HasForeignKey(d => d.IdFormaPago);
                entity.HasOne(d => d.Usuario).WithMany(p => p.Pedidos).HasForeignKey(d => d.IdUsuario);
                entity.HasOne(d => d.Direccion).WithMany(p => p.Pedidos).HasForeignKey(d => d.IdDireccion);
            });

            modelBuilder.Entity<PedidoDetalle>(entity =>
            {
                entity.HasOne(d => d.ProductoDetalle).WithMany(p => p.PedidoDetalles).HasForeignKey(d => d.IdProductoDetalle);
                entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoDetalles).HasForeignKey(d => d.IdPedido);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Precio).HasColumnType("numeric(25,2)");
                entity.HasOne(d => d.CategoriaProducto).WithMany(p => p.Productos).HasForeignKey(d => d.IdCategoriaProducto);
            });

            modelBuilder.Entity<ProductoCaracteristica>(entity =>
            {
                entity.HasOne(d => d.ProductoDetalle).WithMany(p => p.ProductoCaracteristicas).HasForeignKey(d => d.IdProductoDetalle);
                entity.HasOne(d => d.Caracteristica).WithMany(p => p.ProductoCaracteristicas).HasForeignKey(d => d.IdCaracteristica);
            });

            modelBuilder.Entity<ProductoDetalle>(entity =>
            {
                entity.Property(e => e.Precio).HasColumnType("numeric(25,2)");
                entity.HasOne(d => d.Producto).WithMany(p => p.ProductoDetalles).HasForeignKey(d => d.IdProducto);
                entity.HasOne(d => d.Empresa).WithMany(p => p.ProductoDetalles).HasForeignKey(d => d.IdEmpresa);
            });

            modelBuilder.Entity<Promocion>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<PromocionCategoria>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100);
                entity.HasOne(d => d.CategoriaProducto).WithMany(p => p.PromocionCategorias).HasForeignKey(d => d.IdCategoriaProducto);
                entity.HasOne(d => d.Promocion).WithMany(p => p.PromocionCategorias).HasForeignKey(d => d.IdPromocion);
                entity.HasOne(d => d.Empresa).WithMany(p => p.PromocionCategorias).HasForeignKey(d => d.IdEmpresa);
            });

            modelBuilder.Entity<PromocionProducto>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100);
                entity.HasOne(d => d.Producto).WithMany(p => p.PromocionProductos).HasForeignKey(d => d.IdProducto);
                entity.HasOne(d => d.Promocion).WithMany(p => p.PromocionProductos).HasForeignKey(d => d.IdPromocion);
            });

            modelBuilder.Entity<TipoCaracteristica>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100).IsRequired();
                entity.HasOne(d => d.CategoriaProducto).WithMany(p => p.TipoCaracteristicas).HasForeignKey(d => d.IdCategoriaProducto);
            });

            modelBuilder.Entity<TipoFormaPago>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.User).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Apellido).HasMaxLength(100).IsRequired();
                entity.Property(e => e.DNI).HasMaxLength(25);
                entity.Property(e => e.TelefonoPrincipal).HasMaxLength(100);
                entity.Property(e => e.TelefonoPrincipal).HasMaxLength(100);
                entity.Property(e => e.Imagen).HasMaxLength(5000);
                entity.HasOne(d => d.Perfil).WithMany(p => p.Usuarios).HasForeignKey(d => d.IdPerfil);
                entity.HasOne(d => d.Empresa).WithMany(p => p.Usuarios).HasForeignKey(d => d.IdEmpresa);
            });
        }
    }
}
