USE DBPUNTO_VENTA

GO

--PROCEDIMIENTO PARA GUARDAR PERSONA
create PROC sp_RegistrarPersona(
@Documento varchar(50),
@Nombre varchar(50),
@Direccion varchar(50),
@Telefono varchar(50),
@Clave varchar(50),
@IdTipoPersona int,
@Resultado int output
)as
begin
	SET @Resultado = 0
	DECLARE @IDPERSONA INT 
	IF NOT EXISTS (SELECT * FROM persona WHERE Documento = @Documento)
	begin
		insert into persona(Documento,Nombre,Direccion,Telefono,Clave,IdTipoPersona) values (
		@Documento,@Nombre,@Direccion,@Telefono,@Clave,@IdTipoPersona)

		set @Resultado = SCOPE_IDENTITY()
	end
	
end

go

--PROCEDIMIENTO PARA MODIFICAR PERSONA
create procedure sp_ModificarPersona(
@IdPersona int,
@Documento varchar(50),
@Nombre varchar(50),
@Direccion varchar(50),
@Telefono varchar(50),
@Clave varchar(50),
@IdTipoPersona int,
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM persona WHERE Documento =@Documento and IdPersona != @IdPersona)
		
		update PERSONA set
		Documento = @Documento,
		Nombre = @Nombre,
		Direccion = @Direccion,
		Telefono = @Telefono,
		IdTipoPersona = @IdTipoPersona
		where IdPersona = @IdPersona
	ELSE
		SET @Resultado = 0

end


GO

--PROCEDIMIENTO PARA GUARDAR PROVEEDOR
create PROC sp_RegistrarProveedor(
@Documento varchar(50),
@RazonSocial varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Resultado int output
)as
begin
	SET @Resultado = 0
	DECLARE @IDPERSONA INT 
	IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento)
	begin
		insert into PROVEEDOR(Documento,RazonSocial,Correo,Telefono) values (
		@Documento,@RazonSocial,@Correo,@Telefono)

		set @Resultado = SCOPE_IDENTITY()
	end
	
end

go


--PROCEDIMIENTO PARA MODIFICAR PROVEEDOR
create procedure sp_ModificarProveedor(
@IdProveedor int,
@Documento varchar(50),
@RazonSocial varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento =@Documento and IdProveedor != @IdProveedor)
		
		update PROVEEDOR set
		Documento = @Documento,
		RazonSocial = @RazonSocial,
		Correo = @Correo,
		Telefono = @Telefono
		where IdProveedor = @IdProveedor
	ELSE
		SET @Resultado = 0

end


GO

--PROCEDIMIENTO PARA GUARDAR CATEGORIA
create PROC sp_RegistrarCategoria(
@Descripcion varchar(50),
@Resultado int output
)as
begin
	SET @Resultado = 0
	DECLARE @IDPERSONA INT 
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
	begin
		insert into CATEGORIA(Descripcion) values (@Descripcion)

		set @Resultado = SCOPE_IDENTITY()
	end
	
end


go


--PROCEDIMIENTO PARA MODIFICAR CATEGORIA
create procedure sp_ModificarCategoria(
@IdCategoria int,
@Descripcion varchar(50),
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion =@Descripcion and IdCategoria != @IdCategoria)
		
		update CATEGORIA set
		Descripcion = @Descripcion
		where IdCategoria = @IdCategoria
	ELSE
		SET @Resultado = 0

end


GO

--PROCEDIMIENTO PARA GUARDAR PRODUCTO
create PROC sp_RegistrarProducto(
@Codigo varchar(20),
@Nombre varchar(30),
@Descripcion varchar(30),
@IdCategoria int,
@Resultado int output
)as
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM producto WHERE Codigo = @Codigo)
	begin
		insert into producto(Codigo,Nombre,Descripcion,IdCategoria) values (@Codigo,@Nombre,@Descripcion,@IdCategoria)

		set @Resultado = SCOPE_IDENTITY()
	end
	
end

go

--PROCEDIMIENTO PARA MODIFICAR PRODUCTO
create procedure sp_ModificarProducto(
@IdProducto int,
@Codigo varchar(20),
@Nombre varchar(30),
@Descripcion varchar(30),
@IdCategoria int,
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE codigo =@Codigo and IdProducto != @IdProducto)
		
		update PRODUCTO set
		codigo = @Codigo,
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		IdCategoria = @IdCategoria
		where IdProducto = @IdProducto
	ELSE
		SET @Resultado = 0

end

