USE [MASTER];
go

CREATE DATABASE [DBPUNTO_VENTA];
GO

USE [DBPUNTO_VENTA];
GO

CREATE TABLE [TIPO_PERSONA]
(
  IdTipoPersona   [int]               not null identity(1,1),
  Descripcion     [varchar]   (255)   not null,
  Estado          [bit]               not null default 1,
  FechaCreacion   [datetime]          not null default getutcdate(),
  CONSTRAINT      [pk_IdTipoPersona]  PRIMARY KEY CLUSTERED([IdTipoPersona])
);
go

CREATE TABLE [PERSONA]
(
  IdPersona       [int]               not null identity(1,1),
  Documento       [varchar]  (15)     not null,
  Nombre          [varchar]  (255)    not null,
  Direccion       [varchar]  (255)    not null,
  Telefono        [varchar]  (255)    not null,
  Clave           [varchar]  (50)     not null,
  IdTipoPersona   [int]               not null,
  Estado          [bit]               not null default 1,
  FechaCreacion   [datetime]          not null default getutcdate(),
  CONSTRAINT      [pk_IdPersona]      PRIMARY KEY CLUSTERED([IdPersona]),
  CONSTRAINT      [fk_IdPersona]      FOREIGN KEY ([IdTipoPersona]) references TIPO_PERSONA([IdTipoPersona])
);
GO

CREATE TABLE [PROVEEDOR]
(
  IdProveedor     [int]               not null identity(1,1),
  Documento       [varchar] (15)      not null,
  RazonSocial     [varchar] (255)     not null,
  Correo          [varchar] (255)     not null,
  Telefono        [varchar] (50)      not null,
  Estado          [bit]               not null default 1,
  FechaCreacion   [datetime]          not null default getutcdate(),
  CONSTRAINT      [pk_IdProveedor]    PRIMARY KEY CLUSTERED([IdProveedor])
);
GO

CREATE TABLE [CATEGORIA]
(
  IdCategoria     [int]               not null identity(1,1),
  Descripcion     [varchar] (255)     not null,
  Estado          [bit]               not null default 1,
  FechaCreacion   [datetime]          not null default getutcdate(),
  CONSTRAINT      [pk_IdCategoria]    PRIMARY KEY CLUSTERED([IdCategoria])
);
GO

CREATE TABLE [PRODUCTO]
(
  IdProducto      [int]               not null identity(1,1),
  Codigo          [varchar]  (20)     not null,
  Nombre          [varchar]  (255)    not null,
  Descripcion     [varchar]  (255)    not null,
  IdCategoria     [int]               not null,
  Stock           [int]               not null default 0,
  PrecioCompra    [decimal]  (10,2)   not null default 0,
  PrecioVenta     [decimal]  (10,2)   not null default 0,
  Estado          [bit]               not null default 1,
  FechaCreacion   [datetime]          not null default getutcdate(),
  CONSTRAINT      [pk_IdProducto]     PRIMARY KEY CLUSTERED([IdProducto]),
  CONSTRAINT      [fk_IdProducto]     FOREIGN KEY ([IdCategoria]) references CATEGORIA([IdCategoria])
);
GO

CREATE TABLE [TIENDA]
(
  IdTienda        [int]               not null identity(1,1),
  Documento       [varchar]   (50)    not null,
  RazonSocial     [varchar]   (255)   not null,
  Correo          [varchar]   (255)   not null,
  Telefono        [varchar]   (50)    not null,
  CONSTRAINT      [pk_IdTienda]       PRIMARY KEY (IdTienda)
);
GO

create table [COMPRA]
(
  IdCompra         [int]               not null identity(1,1),
  IdPersona        [int]               not null,
  IdProveedor      [int]               not null,
  MontoTotal       [decimal]  (10,2)   not null default 0,
  TipoDocumento    [varchar]  (50)     not null default 'Boleta',
  NumeroDocumento  [varchar]  (50)     not null,
  FechaRegistro    [datetime]          not null default getutcdate(),
  CONSTRAINT       [pk_IdCompraHead]   PRIMARY KEY (IdCompra),
  CONSTRAINT       [fk_IdCompraHead1]  FOREIGN KEY ([IdPersona]) references PERSONA([IdPersona]),
  CONSTRAINT       [fk_IdCompraHead2]  FOREIGN KEY ([IdProveedor]) references PROVEEDOR([IdProveedor])
);
GO

create table [DETALLE_COMPRA]
(
  IdDetalleCompra  [int]               not null identity(1,1),
  IdCompra         [int]               not null,
  IdProducto       [int]               not null,
  Cantidad         [int]               not null,
  PrecioCompra     [decimal]   (10,2)  not null,
  PrecioVenta      [decimal]   (10,2)  not null,
  Total            [decimal]   (10,2)  not null,
  FechaRegistro    [datetime]          not null default getutcdate(),
  CONSTRAINT       [pk_IdCompraDet]    PRIMARY KEY (IdDetalleCompra),
  CONSTRAINT       [fk_IdCompraDet1]   FOREIGN KEY ([IdCompra]) references COMPRA([IdCompra]),
  CONSTRAINT       [fk_IdCompraDet2]   FOREIGN KEY ([IdProducto]) references Producto(IdProducto)
);
GO

create table [VENTA]
(
  IdVenta          [int]              not null identity(1,1),
  TipoDocumento    [varchar]   (50)   not null,
  NumeroDocumento  [varchar]   (100)  not null,
  IdUsuario        [int]              not null,
  DocumentoCliente [varchar]   (255)  not null,
  NombreCliente    [varchar]   (255)  not null,
  TotalPagar       [decimal]   (10,2) not null,
  PagoCon          [decimal]   (10,2) not null,
  Cambio           [decimal]   (10,2) not null,
  FechaRegistro    [datetime]         not null default getutcdate(),
  CONSTRAINT       [pk_IdVentaHead]   PRIMARY KEY (IdVenta),
  CONSTRAINT       [fk_IdVentaHead1]  FOREIGN KEY ([IdUsuario]) references PERSONA([IdPersona])
);
GO

create table [DETALLE_VENTA]
(
  IdDetalleVenta   [int]              not null identity(1,1),
  IdVenta          [int]              not null,
  IdProducto       [int]              not null,
  Cantidad         [int]              not null,
  PrecioVenta      [decimal]   (10,2) not null,
  SubTotal         [decimal]   (10,2) not null,
  FechaRegistro    [datetime]         not null default getutcdate(),
  CONSTRAINT       [pk_IdVentaDet]    PRIMARY KEY ([IdDetalleVenta]),
  CONSTRAINT       [fk_IdVentaDet1]   FOREIGN KEY ([IdVenta]) references VENTA([IdVenta]),
  CONSTRAINT       [fk_IdVentaDet2]   FOREIGN KEY ([IdProducto]) references PRODUCTO([IdProducto])
);
GO

-- ==================================
-- Stored Procedures.
-- ==================================
USE DBPUNTO_VENTA

GO

--PROCEDIMIENTO PARA GUARDAR PERSONA
CREATE PROCEDURE procRegistrarPersona(@Documento varchar(50), @Nombre varchar(255), @Direccion varchar(255), @Telefono varchar(255), @Clave varchar(255),
                                      @IdTipoPersona int, @Resultado int output)as
begin
  SET @Resultado = 0;
  DECLARE @IDPERSONA INT;

  IF NOT EXISTS (SELECT * FROM persona WHERE Documento = @Documento)
  begin
    insert into persona(Documento,Nombre,Direccion,Telefono,Clave,IdTipoPersona)
    values (@Documento, @Nombre, @Direccion, @Telefono, @Clave, @IdTipoPersona);
    set @Resultado = SCOPE_IDENTITY();
  end
end
go

--PROCEDIMIENTO PARA MODIFICAR PERSONA
create procedure procModificarPersona(@IdPersona int, @Documento varchar(50), @Nombre varchar(255), @Direccion varchar(255),
                                      @Telefono varchar(50), @Clave varchar(50), @IdTipoPersona int, @Resultado bit output) as
begin
  SET @Resultado = 1;
  IF NOT EXISTS (SELECT * FROM persona WHERE (Documento = @Documento) and (IdPersona != @IdPersona))
    update PERSONA set
           Documento = @Documento,
           Nombre = @Nombre,
           Direccion = @Direccion,
           Telefono = @Telefono,
           IdTipoPersona = @IdTipoPersona
     where (IdPersona = @IdPersona);
  ELSE
    SET @Resultado = 0;
end
GO

--PROCEDIMIENTO PARA GUARDAR PROVEEDOR
create procedure procRegistrarProveedor(@Documento varchar(50), @RazonSocial varchar(255), @Correo varchar(255),
                                        @Telefono varchar(50), @Resultado int output) as
begin
  SET @Resultado = 0;
  DECLARE @IDPERSONA INT;
  IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE (Documento = @Documento))
  begin
    insert into PROVEEDOR(Documento,RazonSocial, Correo, Telefono)
    values (@Documento, @RazonSocial, @Correo, @Telefono);
    set @Resultado = SCOPE_IDENTITY();
  end
end
go

--PROCEDIMIENTO PARA MODIFICAR PROVEEDOR
create procedure procModificarProveedor(@IdProveedor int, @Documento varchar(50), @RazonSocial varchar(255),
                                        @Correo varchar(255), @Telefono varchar(50), @Resultado bit output) as
begin
  SET @Resultado = 1;
  IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE (Documento = @Documento) and (IdProveedor != @IdProveedor))
    update PROVEEDOR
       set Documento = @Documento,
           RazonSocial = @RazonSocial,
           Correo = @Correo,
           Telefono = @Telefono
     where (IdProveedor = @IdProveedor);
  ELSE
    SET @Resultado = 0;
end
GO

--PROCEDIMIENTO PARA GUARDAR CATEGORIA
create procedure procRegistrarCategoria(@Descripcion varchar(255), @Resultado int output) as
begin
  SET @Resultado = 0;
  DECLARE @IDPERSONA INT;
  IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE (Descripcion = @Descripcion))
  begin
    insert into CATEGORIA(Descripcion)
    values (@Descripcion);
    set @Resultado = SCOPE_IDENTITY();
  end
end
go


--PROCEDIMIENTO PARA MODIFICAR CATEGORIA
create procedure procModificarCategoria(@IdCategoria int, @Descripcion varchar(255), @Resultado bit output) as
begin
  SET @Resultado = 1;
  IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE (Descripcion = @Descripcion) and (IdCategoria != @IdCategoria))
      update CATEGORIA
         set Descripcion = @Descripcion
       where (IdCategoria = @IdCategoria);
  ELSE
    SET @Resultado = 0;
end
GO

--PROCEDIMIENTO PARA GUARDAR PRODUCTO
create procedure procRegistrarProducto(@Codigo varchar(20), @Nombre varchar(30), @Descripcion varchar(255),
                                       @IdCategoria int, @Resultado int output) as
begin
  SET @Resultado = 0;
  IF NOT EXISTS (SELECT * FROM producto WHERE (Codigo = @Codigo))
  begin
    insert into producto(Codigo, Nombre, Descripcion, IdCategoria)
    values (@Codigo, @Nombre, @Descripcion, @IdCategoria);
    set @Resultado = SCOPE_IDENTITY();
  end
end
go

--PROCEDIMIENTO PARA MODIFICAR PRODUCTO
create procedure procModificarProducto(@IdProducto int, @Codigo varchar(20), @Nombre varchar(255),
                                       @Descripcion varchar(255), @IdCategoria int, @Resultado bit output) as
begin
  SET @Resultado = 1;
  IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE (codigo = @Codigo) and (IdProducto != @IdProducto))
    update PRODUCTO
       set codigo = @Codigo,
           Nombre = @Nombre,
           Descripcion = @Descripcion,
           IdCategoria = @IdCategoria
     where (IdProducto = @IdProducto);
  ELSE
    SET @Resultado = 0;
end
GO

-- ===================
-- INSERTANDO DATOS.
-- ===================

USE DBPUNTO_VENTA
GO

insert into TIPO_PERSONA(Descripcion) 
values ('Administrador'),
       ('Empleado'),
       ('Cliente');
go


insert into PERSONA(documento, nombre, direccion, telefono, clave, IdTipoPersona) 
values ('10101010', 'Admin', 'S/D', '0', '123', 1),
       ('20202020', 'Empleado', 'S/D', '0', '456', 2);
GO

insert into TIENDA(Documento, RazonSocial, Correo, Telefono) 
VALUES ('0', 'POR DEFINIR', 'DEFAULT@GMAIL.COM', '101010');
GO