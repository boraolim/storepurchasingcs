create database DBPUNTO_VENTA
go
USE DBPUNTO_VENTA

GO

CREATE TABLE TIPO_PERSONA(
IdTipoPersona  int primary key,
Descripcion varchar(50),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

CREATE TABLE PERSONA(
IdPersona int primary key identity,
Documento varchar(15),
Nombre varchar(50),
Direccion varchar(50),
Telefono varchar(50),
Clave varchar(50),
IdTipoPersona int references TIPO_PERSONA(IdTipoPersona),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

CREATE TABLE PROVEEDOR(
IdProveedor int primary key identity,
Documento varchar(15),
RazonSocial varchar(50),
Correo varchar(50),
Telefono varchar(50),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

CREATE TABLE CATEGORIA(
IdCategoria int primary key identity,
Descripcion varchar(15),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

go

CREATE TABLE PRODUCTO(
IdProducto int primary key identity,
Codigo varchar(20),
Nombre varchar(30),
Descripcion varchar(30),
IdCategoria int references CATEGORIA(IdCategoria),
Stock int default 0,
PrecioCompra decimal(10,2) default 0,
PrecioVenta decimal(10,2) default 0,
Estado bit default 1,
FechaCreacion datetime default getdate()
)

GO 

CREATE TABLE TIENDA(
IdTienda int PRIMARY KEY,
Documento varchar(50),
RazonSocial varchar(50),
Correo varchar(50),
Telefono varchar(50)
)

go

create table COMPRA(
IdCompra int primary key identity(1,1),
IdPersona int references Persona(IdPersona),
IdProveedor int references PROVEEDOR(IdProveedor),
MontoTotal decimal(10,2) default 0,
TipoDocumento varchar(50) default 'Boleta',
NumeroDocumento varchar(50),
FechaRegistro datetime default getdate()
)

go

create table DETALLE_COMPRA(
IdDetalleCompra int primary key identity(1,1),
IdCompra int references COMPRA(IdCompra),
IdProducto int references Producto(IdProducto),
Cantidad int,
PrecioCompra decimal(10,2),
PrecioVenta decimal(10,2),
Total decimal(10,2),
FechaRegistro datetime default getdate()
)



go 


create table VENTA(
IdVenta int primary key identity(1,1),
TipoDocumento varchar(50),
NumeroDocumento varchar(100),
IdUsuario int references PERSONA(IdPersona),
DocumentoCliente varchar(50),
NombreCliente varchar(50),
TotalPagar  decimal(10,2),
PagoCon decimal(10,2),
Cambio decimal(10,2),
FechaRegistro datetime default getdate()
)

go

create table DETALLE_VENTA(
IdDetalleVenta int primary key identity(1,1),
IdVenta int references VENTA(IdVenta),
IdProducto int references PRODUCTO(IdProducto),
Cantidad int,
PrecioVenta decimal(10,2),
SubTotal decimal(10,2),
FechaRegistro datetime default getdate()
)

go


