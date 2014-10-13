GO
USE [GD2C2014] 

GO
CREATE SCHEMA LA_REVANCHA


--CREACION DE TABLAS CORRESPONDIENTE AL MODELO DE DATOS PLANTEADO--
GO
CREATE TABLE [LA_REVANCHA].[USUARIO](
			 [USU_CODIGO][NUMERIC](18,0) IDENTITY (1,1),
			 [USU_USERNAME][NVARCHAR](255) UNIQUE,
			 [USU_PASSWORD][NVARCHAR](255),
			 [USU_TIPO][NVARCHAR](50),
			 [USU_HABILITADO] [BIT] DEFAULT 1,
			 [USU_BLOQUEADO] [BIT] DEFAULT 0 ,
PRIMARY KEY CLUSTERED (USU_CODIGO),
)

GO
CREATE TABLE [LA_REVANCHA].[CLIENTE](
			 [CLI_CODIGO][NUMERIC](18,0) IDENTITY (2,2),
			 [CLI_COD_USUARIO][NUMERIC](18,0),
			 [CLI_NOMBRE][NVARCHAR](255),
			 [CLI_APELLIDO][NVARCHAR](255),
			 [CLI_NUMERO_IDENTIFICACION][NUMERIC](18,0),
			 [CLI_TIPO_IDENTIFICACION][NVARCHAR](255) DEFAULT 'DUI',
			 [CLI_MAIL][NVARCHAR](255), -- HAY QUE HACERLO UNIQUE POST MIGRACION
			 [CLI_TELEFONO][NUMERIC](18,0),
			 [CLI_CALLE][NVARCHAR](255),
			 [CLI_NRO_CALLE][NUMERIC](18,0),
			 [CLI_PISO][NUMERIC](18,0),
			 [CLI_DEPARTAMENTO][NVARCHAR](50),
			 [CLI_LOCALIDAD][NVARCHAR](255),
			 [CLI_PAIS_ORIGEN][NVARCHAR](255),
			 [CLI_NACIONALIDAD][NVARCHAR](255),
			 [CLI_FECHA_NACIMIENTO][DATETIME],
PRIMARY KEY CLUSTERED(CLI_CODIGO),
FOREIGN KEY (CLI_COD_USUARIO) REFERENCES LA_REVANCHA.USUARIO(USU_CODIGO)
)
		 

GO
CREATE TABLE [LA_REVANCHA].[PERSONAL](
			 [PER_CODIGO][NUMERIC](18,0) IDENTITY(3,3),
			 [PER_COD_USUARIO][NUMERIC](18,0),
			 [PER_NOMBRE][NVARCHAR](255),
			 [PER_APELLIDO][NVARCHAR](255),
			 [PER_NUMERO_IDENTIFICACION][NVARCHAR](255),
			 [PER_TIPO_IDENTIFICACION][NVARCHAR](255),
			 [PER_MAIL][NVARCHAR](255) UNIQUE,
			 [PER_TELEFONO][NUMERIC](18,0),
			 [PER_DIRECCION][NVARCHAR](255),
			 [PER_FECHA_NACIMIENTO][DATETIME],
PRIMARY KEY CLUSTERED(PER_CODIGO),
FOREIGN KEY (PER_COD_USUARIO) REFERENCES LA_REVANCHA.USUARIO(USU_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[ROL](
		   	 [ROL_CODIGO][INT] IDENTITY(10,10),
	         [ROL_DESCRIPCION][NVARCHAR](255),
	         [ROL_HABILITADO][BIT] default 1, -- ES PARA LA BAJA LOGICA  - HABILITADO POR DEFECTO
PRIMARY KEY CLUSTERED (ROL_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[USUARIO_ROL](
	         [USUROL_USUARIO][NUMERIC](18,0),
	         [USUROL_ROL][INT],
PRIMARY KEY CLUSTERED (USUROL_USUARIO,USUROL_ROL),
FOREIGN KEY (USUROL_USUARIO) REFERENCES LA_REVANCHA.USUARIO(USU_CODIGO),
FOREIGN KEY (USUROL_ROL) REFERENCES LA_REVANCHA.ROL(ROL_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[FUNCION](
			 [FUN_CODIGO][INT]IDENTITY(101,1),
	         [FUN_DESCRIPCION][NVARCHAR](255),
PRIMARY KEY CLUSTERED (FUN_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[FUNCION_ROL](
	         [FUNROL_ROL][INT],
    	     [FUNROL_FUNCION][INT],
    	     [FUNROL_HABILITADO][BIT] DEFAULT 1,-- ES PARA LA BAJA LOGICA  - HABILITADO POR DEFECTO
FOREIGN KEY (FUNROL_ROL) REFERENCES LA_REVANCHA.ROL(ROL_CODIGO),
FOREIGN KEY (FUNROL_FUNCION) REFERENCES LA_REVANCHA.FUNCION(FUN_CODIGO)	
)

GO
CREATE TABLE [LA_REVANCHA].[REGIMEN](
			 [REG_CODIGO][NUMERIC](18,0) IDENTITY (100,10),
			 [REG_DESCRIPCION][NVARCHAR](255),
			 [REG_PRECIO][NUMERIC](18,2),
			 [REG_HABILITADO][BIT] default 1, -- ES PARA LA BAJA LOGICA  - HABILITADO POR DEFECTO
PRIMARY KEY CLUSTERED (REG_CODIGO)
)

GO 
CREATE TABLE [LA_REVANCHA].[HOTEL](
			 [HOT_CODIGO][NUMERIC](18,0) IDENTITY (1000,100),
			 [HOT_NOMBRE][NVARCHAR](255),
			 [HOT_MAIL][NVARCHAR](255),
			 [HOT_TELEFONO][NUMERIC](18,0),
			 [HOT_CALLE][NVARCHAR](255),
			 [HOT_NRO_CALLE][NUMERIC](18,0),
			 [HOT_ESTRELLAS][NUMERIC](18,0),
			 [HOT_RECARGA_ESTRELLAS][NUMERIC](18,0),
			 [HOT_CIUDAD][NVARCHAR](255),
			 [HOT_PAIS][NVARCHAR](255),
			 [HOT_FECHA_CREACION][DATETIME],
			 [HOT_HABILITADO] [BIT] DEFAULT 1, --ES PARA LA BAJA LOGICA - POR DEFECTO ESTA DADO DE ALTA
PRIMARY KEY CLUSTERED (HOT_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[HOTEL_REGIMEN](
			 [HOTREG_COD_HOTEL][NUMERIC](18,0),
			 [HOTREG_COD_REGIMEN][NUMERIC](18,0),
			 [HOTREG_HABILITADO][BIT] default 1, -- ES PARA LA BAJA LOGICA - HABILITADO POR DEFECTO
PRIMARY KEY CLUSTERED (HOTREG_COD_HOTEL,HOTREG_COD_REGIMEN),
FOREIGN KEY (HOTREG_COD_HOTEL) REFERENCES LA_REVANCHA.HOTEL(HOT_CODIGO),
FOREIGN KEY (HOTREG_COD_REGIMEN) REFERENCES LA_REVANCHA.REGIMEN(REG_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[TIPO_HABITACION](
			 [TIPHAB_CODIGO][NUMERIC](18,0),
			 [TIPHAB_DESCRIPCION][NVARCHAR](255),
			 [TIPHAB_PORCENTUAL][NUMERIC](18,2),
			 [TIPHAB_CANT_PERSONAS][NUMERIC](18,0)
PRIMARY KEY CLUSTERED (TIPHAB_CODIGO)
)	
			 
GO
CREATE TABLE [LA_REVANCHA].[HABITACION](
			 [HAB_CODIGO][NUMERIC](18,0) IDENTITY (200,20),
			 [HAB_NUMERO][NUMERIC](18,0),
			 [HAB_COD_HOTEL][NUMERIC](18,0),
			 [HAB_PISO][NUMERIC](18,0),
			 [HAB_UBICACION][NVARCHAR](50),
			 [HAB_COD_TIPOHABITACION][NUMERIC](18,0),
			 [HAB_HABILITADA][BIT] DEFAULT 1,
			 [HAB_DESCRIPCION][NVARCHAR](255),
PRIMARY KEY CLUSTERED(HAB_CODIGO), 
FOREIGN KEY (HAB_COD_HOTEL) REFERENCES LA_REVANCHA.HOTEL(HOT_CODIGO),
FOREIGN KEY (HAB_COD_TIPOHABITACION) REFERENCES LA_REVANCHA.TIPO_HABITACION(TIPHAB_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[HOTEL_CERRADO](
			 [HOTCERR_CODIGO][NUMERIC](18,0) IDENTITY(300,2),
			 [HOTCERR_COD_HOTEL][NUMERIC](18,0),
			 [HOTCERR_FECHA_DESDE][DATETIME],
			 [HOTCERR_FECHA_HASTA][DATETIME],
			 [HOTCERR_MOTIVO][NVARCHAR](255),
PRIMARY KEY CLUSTERED (HOTCERR_CODIGO),
FOREIGN KEY (HOTCERR_COD_HOTEL) REFERENCES LA_REVANCHA.HOTEL(HOT_CODIGO)
)

CREATE TABLE [LA_REVANCHA].[HOTEL_USUARIO](
			 [HOTUSU_COD_USUARIO][NUMERIC](18,0),
			 [HOTCERR_COD_HOTEL][NUMERIC](18,0),
			 [HOTCERR_HABILITADO] [BIT],
PRIMARY KEY CLUSTERED (HOTUSU_COD_USUARIO,HOTCERR_COD_HOTEL),
FOREIGN KEY (HOTUSU_COD_USUARIO) REFERENCES LA_REVANCHA.USUARIO(USU_CODIGO),
FOREIGN KEY (HOTCERR_COD_HOTEL) REFERENCES LA_REVANCHA.HOTEL(HOT_CODIGO)			 
)

GO
CREATE TABLE [LA_REVANCHA].[CONSUMBILES](
			 [CONS_CODIGO][NUMERIC](18,0),
			 [CONS_DESCRIPCION][NVARCHAR](255),
			 [CONS_PRECIO][NUMERIC](18,2)
PRIMARY KEY CLUSTERED (CONS_CODIGO)
)	

GO
CREATE TABLE [LA_REVANCHA].[FORMA_PAGO](
			 [PAGO_CODIGO][NUMERIC](18,0) IDENTITY(2000,100),
			 [PAGO_DESCRIPCION][NVARCHAR](255),
			 [PAGO_NOMBRE][NVARCHAR](255),
			 [PAGO_APELLIDO][NVARCHAR](255),
			 [PAGO_NRO_TARJETA][NUMERIC](18,0),
PRIMARY KEY CLUSTERED (PAGO_CODIGO)
)	

GO
CREATE TABLE [LA_REVANCHA].[ESTADO_RESERVA](
			 [ESTRES_CODIGO][NUMERIC](18,0) IDENTITY(4000,1),
			 [ESTRES_DESCRIPCION][NVARCHAR](255),
PRIMARY KEY CLUSTERED (ESTRES_CODIGO)
)		

GO
CREATE TABLE [LA_REVANCHA].[RESERVA](
			 [RES_CODIGO][NUMERIC](18,0),
			 [RES_FECHA_CARGA][DATETIME],
			 [RES_FECHA_DESDE][DATETIME],
			 [RES_FECHA_HASTA][DATETIME],
			 [RES_HOTREG_HOTEL][NUMERIC](18,0),
			 [RES_HOTREG_REGIMEN][NUMERIC](18,0),
			 [RES_ESTRES_CODIGO][NUMERIC](18,0) DEFAULT 4000, --POR DEFECTO TIENE EL CODIGO DE ESTADO_RESERVA=CORRECTA
PRIMARY KEY CLUSTERED (RES_CODIGO),
FOREIGN KEY (RES_HOTREG_HOTEL,RES_HOTREG_REGIMEN) REFERENCES LA_REVANCHA.HOTEL_REGIMEN(HOTREG_COD_HOTEL,HOTREG_COD_REGIMEN),
FOREIGN KEY (RES_ESTRES_CODIGO) REFERENCES LA_REVANCHA.ESTADO_RESERVA(ESTRES_CODIGO)
)
			
			
GO 
CREATE TABLE [LA_REVANCHA].[CANCELACION](
				[CANC_CODIGO][NUMERIC](18,0) IDENTITY (3000,2),
				[CANC_COD_RESERVA][NUMERIC](18,0),
				[CANC_MOTIVO][NVARCHAR](255),
				[CANC_FECHA][DATETIME],
				[CANC_COD_USUARIO][NUMERIC](18,0),		 
PRIMARY KEY CLUSTERED (CANC_CODIGO),
FOREIGN KEY(CANC_COD_RESERVA) REFERENCES LA_REVANCHA.RESERVA(RES_CODIGO),
FOREIGN KEY (CANC_COD_USUARIO) REFERENCES LA_REVANCHA.USUARIO(USU_CODIGO)
)		 

GO
CREATE TABLE [LA_REVANCHA].[HABITACION_RESERVA](
			 [HABRES_COD_RESERVA][NUMERIC](18,0),
			 [HABRES_COD_HABITACION][NUMERIC](18,0),
PRIMARY KEY CLUSTERED (HABRES_COD_RESERVA,HABRES_COD_HABITACION),
FOREIGN KEY (HABRES_COD_RESERVA) REFERENCES LA_REVANCHA.RESERVA(RES_CODIGO),
FOREIGN KEY (HABRES_COD_HABITACION) REFERENCES LA_REVANCHA.HABITACION(HAB_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[FACTURA](
			 [FAC_CODIGO][NUMERIC](18,0),
			 [FAC_DIAS_ALOJADOS][NUMERIC](18,0),
			 [FAC_DIAS_NO_ALOJADOS][NUMERIC](18,0),
			 [FAC_FECHA][DATETIME],
			 [FAC_TOTAL][NUMERIC](18,2),
			 [FAC_COD_FORMA_PAGO][NUMERIC](18,0),
			 [FAC_COD_RESERVA][NUMERIC](18,0),	 
PRIMARY KEY CLUSTERED (FAC_CODIGO),
FOREIGN KEY (FAC_COD_FORMA_PAGO) REFERENCES LA_REVANCHA.FORMA_PAGO(PAGO_CODIGO),
FOREIGN KEY (FAC_COD_RESERVA) REFERENCES LA_REVANCHA.RESERVA(RES_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[FACTURA_ITEM](
			 [FACITEM_CODIGO][NUMERIC](18,0) IDENTITY (5000,1),
			 [FACITEM_COD_FACTURA][NUMERIC](18,0),
			 [FACITEM_COD_CONSUMIBLE][NUMERIC](18,0),
			 [FACITEM_CANTIDAD][NUMERIC](18,0),
			 [FACITEM_MONTO][NUMERIC](18,2),
PRIMARY KEY CLUSTERED (FACITEM_CODIGO),
FOREIGN KEY (FACITEM_COD_FACTURA) REFERENCES LA_REVANCHA.FACTURA(FAC_CODIGO),
FOREIGN KEY (FACITEM_COD_CONSUMIBLE) REFERENCES LA_REVANCHA.CONSUMBILES(CONS_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[RESERVA_USUARIO](
			 [RESUSU_COD_RESERVA][NUMERIC](18,0),
			 [RESUSU_CODUSU_HUESPED][NUMERIC](18,0),
			 [RESUSU_CODUSU_OPERADOR][NUMERIC](18,0),
			 [RESUSU_CHECKIN][DATETIME],
			 [RESUSU_CHECKOUT][DATETIME],
PRIMARY KEY CLUSTERED (RESUSU_COD_RESERVA,RESUSU_CODUSU_HUESPED),
FOREIGN KEY (RESUSU_COD_RESERVA) REFERENCES LA_REVANCHA.RESERVA(RES_CODIGO),
FOREIGN KEY (RESUSU_CODUSU_HUESPED) REFERENCES LA_REVANCHA.USUARIO(USU_CODIGO),
FOREIGN KEY (RESUSU_CODUSU_OPERADOR) REFERENCES LA_REVANCHA.USUARIO(USU_CODIGO)
)

--MIGRACION DE LA TABLA MAESTRA---


--MIGRANDO TIPO_HABITACION-- 5 FILAS
GO
INSERT INTO LA_REVANCHA.TIPO_HABITACION(TIPHAB_CODIGO,TIPHAB_DESCRIPCION,TIPHAB_PORCENTUAL)
SELECT DISTINCT(Habitacion_Tipo_Codigo), Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra


--MIGRANDO REGIMEN-- 4 FILAS
GO
INSERT INTO LA_REVANCHA.REGIMEN(REG_DESCRIPCION,REG_PRECIO)
SELECT DISTINCT(Regimen_Descripcion),Regimen_Precio
FROM gd_esquema.Maestra

--MIGRANDO CONSUMIBLES-- 4 FILAS
GO
INSERT INTO LA_REVANCHA.CONSUMBILES(CONS_CODIGO,CONS_DESCRIPCION,CONS_PRECIO)
SELECT DISTINCT(Consumible_Codigo),Consumible_Descripcion,Consumible_Precio
FROM gd_esquema.Maestra
WHERE Consumible_Codigo IS NOT NULL

--DATOS DE LOS HOTELES-- 16 FILAS
GO
INSERT INTO LA_REVANCHA.HOTEL(HOT_CALLE, HOT_NRO_CALLE, HOT_CIUDAD,
 HOT_ESTRELLAS,HOT_RECARGA_ESTRELLAS)
select distinct Hotel_Calle,Hotel_Nro_Calle,Hotel_Ciudad,Hotel_CantEstrella,Hotel_Recarga_Estrella
from gd_esquema.Maestra

--MIGRACION DE LAS HABITACION-- 345 FILAS
GO
INSERT INTO LA_REVANCHA.HABITACION(HAB_NUMERO,HAB_COD_HOTEL,HAB_PISO,HAB_UBICACION,HAB_COD_TIPOHABITACION)
SELECT DISTINCT Habitacion_Numero, (SELECT DISTINCT HOT_CODIGO
						   FROM LA_REVANCHA.HOTEL
						   WHERE HOT_CALLE = Hotel_Calle AND HOT_NRO_CALLE = Hotel_Nro_Calle) AS HAB_COD_HOTEL, 
						   Habitacion_Piso, Habitacion_Frente, (SELECT DISTINCT TIPHAB_CODIGO
																FROM LA_REVANCHA.TIPO_HABITACION
																WHERE TIPHAB_CODIGO = Habitacion_Tipo_Codigo)AS HAB_COD_TIPOHABITACION				   
FROM gd_esquema.Maestra

--TABLA USUARIOS_CLIENTES - 100740 FILAS
--EL NOMBRE DE USUARIO ES EL DNI+1 LETRA DEL APELLIDO + 1 LETRA DEL NOMBRE.
GO
CREATE VIEW LA_REVANCHA.VIEW_CLIENTES_MAESTRA
AS
select DISTINCT Cliente_Pasaporte_Nro,Cliente_Apellido,Cliente_Nombre,Cliente_Fecha_Nac,Cliente_Mail,Cliente_Dom_Calle,
Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,Cliente_Nacionalidad
from gd_esquema.Maestra
GO
INSERT INTO LA_REVANCHA.USUARIO(USU_USERNAME, USU_PASSWORD, USU_TIPO)
select CAST(VC.Cliente_Pasaporte_Nro AS VARCHAR)+CAST(SUBSTRING(VC.Cliente_Apellido,1,1) AS VARCHAR)+
CAST( SUBSTRING(VC.Cliente_Nombre,1,1) AS VARCHAR) AS USERNAME,
CAST(VC.Cliente_Pasaporte_Nro AS VARCHAR)+CAST(SUBSTRING(VC.Cliente_Apellido,1,1) AS VARCHAR)+
CAST( SUBSTRING(VC.Cliente_Nombre,1,1) AS VARCHAR) AS CONTRASENIA,'CLIENTE'
FROM LA_REVANCHA.VIEW_CLIENTES_MAESTRA VC

--TABLA USUARIOS_EMPLEADOS - 0 FILAS

--TABLA USUARIOS - ADMINISTRADOR GENERAL
GO
INSERT INTO LA_REVANCHA.USUARIO(USU_USERNAME, USU_PASSWORD, USU_TIPO)
VALUES ('ADMIN','W23E','GOD')

--TABLA CLIENTES
INSERT INTO LA_REVANCHA.CLIENTE(CLI_COD_USUARIO, CLI_NOMBRE, CLI_APELLIDO, CLI_NUMERO_IDENTIFICACION,
 CLI_MAIL, CLI_CALLE, CLI_NRO_CALLE, CLI_PISO, CLI_DEPARTAMENTO,CLI_NACIONALIDAD, CLI_FECHA_NACIMIENTO)
 
 SELECT U.USU_CODIGO,VC.Cliente_Nombre,VC.Cliente_Apellido,VC.Cliente_Pasaporte_Nro,VC.Cliente_Mail,
 VC.Cliente_Dom_Calle,VC.Cliente_Nro_Calle,VC.Cliente_Piso,VC.Cliente_Depto,VC.Cliente_Nacionalidad,
 VC.Cliente_Fecha_Nac
 FROM LA_REVANCHA.VIEW_CLIENTES_MAESTRA VC JOIN LA_REVANCHA.USUARIO U ON
 U.USU_USERNAME=CAST(VC.Cliente_Pasaporte_Nro AS VARCHAR)+CAST(SUBSTRING(VC.Cliente_Apellido,1,1) AS VARCHAR)+
CAST( SUBSTRING(VC.Cliente_Nombre,1,1) AS VARCHAR)

--TABLA FORMAS DE PAGO - 2 FILAS -- CODIGO 2000 Y 2100
GO
INSERT INTO LA_REVANCHA.FORMA_PAGO(PAGO_DESCRIPCION)
VALUES	('EFECTIVO'),
		('TARJETA DE CREDITO')

--TABLA ESTADO_RESERVA - 6 FILLAS
GO
INSERT INTO LA_REVANCHA.ESTADO_RESERVA(ESTRES_DESCRIPCION)
VALUES	('CORRECTA'),
		('MODIFICADA'),
		('CANCELADA POR RECEPCION'),
		('CANCELADA POR CLIENTE'),
		('CANCELADA POR NO-SHOW'),
		('EFECTIVIZADA')


--TABLA HOTEL_REGIMEN - 64 FILAS
GO
CREATE VIEW LA_REVANCHA.VIEW_HOTEL_REGIMEN
AS
select distinct Hotel_Nro_Calle,Regimen_Descripcion 
from gd_esquema.Maestra 
GO
INSERT INTO LA_REVANCHA.HOTEL_REGIMEN(HOTREG_COD_HOTEL,HOTREG_COD_REGIMEN)
SELECT H.HOT_CODIGO,R.REG_CODIGO
FROM LA_REVANCHA.VIEW_HOTEL_REGIMEN V JOIN LA_REVANCHA.HOTEL H ON 
V.Hotel_Nro_Calle=H.HOT_NRO_CALLE JOIN LA_REVANCHA.REGIMEN R ON
V.Regimen_Descripcion=R.REG_DESCRIPCION
ORDER BY H.HOT_CODIGO


--TABLA RESERVAS -- 100740
INSERT INTO LA_REVANCHA.RESERVA(RES_CODIGO,RES_FECHA_DESDE, RES_FECHA_HASTA, RES_HOTREG_HOTEL, RES_HOTREG_REGIMEN)
select distinct Reserva_Codigo,Reserva_Fecha_Inicio, DATEADD(DAY,Reserva_Cant_Noches,Reserva_Fecha_Inicio)as Reserva_Fecha_Fin,
H.HOT_CODIGO, R.REG_CODIGO
from gd_esquema.Maestra JOIN LA_REVANCHA.HOTEL H ON H.HOT_CALLE=Hotel_Calle AND H.HOT_NRO_CALLE=Hotel_Nro_Calle
 AND H.HOT_CIUDAD=Hotel_Ciudad JOIN LA_REVANCHA.REGIMEN R ON R.REG_DESCRIPCION=Regimen_Descripcion
where Reserva_Codigo is not null
order by Reserva_Codigo

--TABLA FUNCION
INSERT INTO LA_REVANCHA.FUNCION(FUN_DESCRIPCION)
VALUES ('ABM Rol'),
	   ('ABM Empleado'),
	   ('ABM Cliente'),
	   ('ABM Hotel'),
	   ('ABM Habitaci�n'),
	   ('ABM Reserva'),
	   ('Registro Estad�a'),
	   ('Registro Consumibles'),
	   ('Facturar Estad�a'),
	   ('Listado Estad�stico')

--TABLA ROL	   
INSERT INTO LA_REVANCHA.ROL(ROL_DESCRIPCION)
VALUES ('ADMIN'),
	   ('RECEP'),
	   ('CLIENTE'),
	   ('GOD')
	   
--TABLA FUNCION_ROL ADMIN
INSERT INTO LA_REVANCHA.FUNCION_ROL(FUNROL_ROL,FUNROL_FUNCION)
SELECT 10,FUN_CODIGO 
FROM LA_REVANCHA.FUNCION 

UPDATE LA_REVANCHA.FUNCION_ROL SET FUNROL_HABILITADO = 0
WHERE FUNROL_ROL = 10 AND (FUNROL_FUNCION = 103 OR FUNROL_FUNCION  = 106 OR FUNROL_FUNCION  = 107 OR FUNROL_FUNCION  = 108 OR FUNROL_FUNCION  = 109) 
	   
--TABLA FUNCION_ROL RECEP	   
INSERT INTO LA_REVANCHA.FUNCION_ROL(FUNROL_ROL,FUNROL_FUNCION)
SELECT 20,FUN_CODIGO 
FROM LA_REVANCHA.FUNCION 

UPDATE LA_REVANCHA.FUNCION_ROL SET FUNROL_HABILITADO = 0
WHERE FUNROL_ROL = 20 AND (FUNROL_FUNCION = 101 OR FUNROL_FUNCION  = 102 OR FUNROL_FUNCION  = 104 OR FUNROL_FUNCION  = 105 OR FUNROL_FUNCION  = 110) 
	

--TABLA FUNCION_ROL CLIENTE
INSERT INTO LA_REVANCHA.FUNCION_ROL(FUNROL_ROL,FUNROL_FUNCION)
SELECT 30,FUN_CODIGO 
FROM LA_REVANCHA.FUNCION 


UPDATE LA_REVANCHA.FUNCION_ROL SET FUNROL_HABILITADO = 0
WHERE FUNROL_ROL = 30 AND (FUNROL_FUNCION = 101 OR FUNROL_FUNCION  = 102 OR FUNROL_FUNCION  = 103 OR FUNROL_FUNCION  = 104 OR FUNROL_FUNCION  = 105 OR
						   FUNROL_FUNCION = 107 OR FUNROL_FUNCION  = 108 OR FUNROL_FUNCION  = 109 OR FUNROL_FUNCION = 110) 
	
--TABLA FUNCION_ROL GOD
INSERT INTO LA_REVANCHA.FUNCION_ROL(FUNROL_ROL,FUNROL_FUNCION)
SELECT 40,FUN_CODIGO 
FROM LA_REVANCHA.FUNCION 

--TABLA USUARIO_ROL CLIENTE
INSERT INTO LA_REVANCHA.USUARIO_ROL(USUROL_USUARIO,USUROL_ROL)
SELECT USU_CODIGO,30
FROM LA_REVANCHA.USUARIO
WHERE USU_TIPO = 'CLIENTE'
 	   
--TABLA USUARIO_ROL ADMIN
INSERT INTO LA_REVANCHA.USUARIO_ROL(USUROL_USUARIO,USUROL_ROL)
SELECT USU_CODIGO,10
FROM LA_REVANCHA.USUARIO
WHERE USU_TIPO = 'ADMIN'

--TABLA USUARIO_ROL RECEP
INSERT INTO LA_REVANCHA.USUARIO_ROL(USUROL_USUARIO,USUROL_ROL)
SELECT USU_CODIGO,20
FROM LA_REVANCHA.USUARIO
WHERE USU_TIPO = 'RECEP'

--TABLA USUARIO_ROL GOD
INSERT INTO LA_REVANCHA.USUARIO_ROL(USUROL_USUARIO,USUROL_ROL)
SELECT USU_CODIGO,40
FROM LA_REVANCHA.USUARIO
WHERE USU_TIPO = 'GOD'



--TABLA HABITACION_RESERVA -- 100740
INSERT INTO LA_REVANCHA.HABITACION_RESERVA(HABRES_COD_RESERVA, HABRES_COD_HABITACION)
select distinct Reserva_Codigo, HA.HAB_CODIGO
from gd_esquema.Maestra JOIN LA_REVANCHA.HOTEL H ON H.HOT_CALLE=Hotel_Calle AND H.HOT_NRO_CALLE=Hotel_Nro_Calle
 AND H.HOT_CIUDAD=Hotel_Ciudad  JOIN LA_REVANCHA.HABITACION HA ON HA.HAB_NUMERO=Habitacion_Numero AND 
 HA.HAB_COD_HOTEL=H.HOT_CODIGO
where Reserva_Codigo is not null
order by Reserva_Codigo


--TABLA RESERVA_USUARIO --100746
INSERT INTO LA_REVANCHA.RESERVA_USUARIO(RESUSU_COD_RESERVA,RESUSU_CODUSU_HUESPED,RESUSU_CODUSU_OPERADOR)
select distinct Reserva_Codigo, C.CLI_COD_USUARIO, (SELECT USU_CODIGO
													FROM LA_REVANCHA.USUARIO
													WHERE USU_TIPO='GOD') AS OPERADOR_GOD 
from gd_esquema.Maestra M JOIN LA_REVANCHA.CLIENTE C ON  
C.CLI_NUMERO_IDENTIFICACION=Cliente_Pasaporte_Nro AND
C.CLI_APELLIDO=Cliente_Apellido AND
C.CLI_NOMBRE=Cliente_Nombre --AND
where Reserva_Codigo is not null
order by Reserva_Codigo

--TABLA FACTURA(89603)

INSERT INTO LA_REVANCHA.FACTURA(FAC_CODIGO,FAC_FECHA,FAC_TOTAL,FAC_COD_RESERVA)
SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total, Reserva_Codigo
FROM gd_esquema.Maestra
WHERE Factura_Nro IS NOT NULL

--TABLA FACTURA_ITEM

INSERT INTO LA_REVANCHA.FACTURA_ITEM(FACITEM_COD_FACTURA,FACITEM_COD_CONSUMIBLE,FACITEM_CANTIDAD,FACITEM_MONTO)
SELECT DISTINCT Factura_Nro, Consumible_Codigo, Item_Factura_Cantidad, Item_Factura_Monto
FROM gd_esquema.Maestra
WHERE Factura_Nro IS NOT NULL 







--TRIGGER QUE GENERA AUTOMATICAMENTE EL USERNAME CON SU RESPECTIVA PASSWORD(SE GENERA TAMBIEN EL CODIGO)

GO
CREATE TRIGGER LA_REVANCHA.TR_AUT_USERNAME
ON LA_REVANCHA.CLIENTE
FOR INSERT
AS
	DECLARE @NUMERO_IDENTIFICACION NUMERIC(18,0)
	DECLARE @NUMERO_IDENTIFICACION_VARCHAR NVARCHAR(255)
	DECLARE @APELLIDO NVARCHAR(255)
	DECLARE @NOMBRE NVARCHAR(255)
	DECLARE @USERNAME NVARCHAR(255)
	DECLARE @PASSWORD NVARCHAR (255)
	DECLARE @USERNAME_REPETIDO NVARCHAR(255)
	DECLARE @CLI_COD_USUARIO NUMERIC(18,0)

	SELECT @NUMERO_IDENTIFICACION = CLI_NUMERO_IDENTIFICACION
									FROM inserted	
									WHERE CLI_NUMERO_IDENTIFICACION IS NOT NULL
						
																
	SET @NUMERO_IDENTIFICACION_VARCHAR = CONVERT(NVARCHAR,@NUMERO_IDENTIFICACION)
	
	SELECT @APELLIDO = INSERTED.CLI_APELLIDO
					   FROM inserted
				       WHERE CLI_NUMERO_IDENTIFICACION = inserted.CLI_NUMERO_IDENTIFICACION
				       
	SELECT @NOMBRE = CLI_NOMBRE
					 FROM inserted
					 WHERE CLI_NUMERO_IDENTIFICACION = inserted.CLI_NUMERO_IDENTIFICACION
	
	SET @USERNAME = @NUMERO_IDENTIFICACION_VARCHAR+CAST(SUBSTRING(@APELLIDO,1,1) AS VARCHAR)+
					CAST( SUBSTRING(@NOMBRE,1,1) AS VARCHAR)
				 
	SET @PASSWORD = @NUMERO_IDENTIFICACION_VARCHAR+CAST(SUBSTRING(@APELLIDO,1,1) AS VARCHAR)+
					CAST( SUBSTRING(@NOMBRE,1,1) AS VARCHAR)
	
	SET @USERNAME_REPETIDO = (SELECT USU_USERNAME
							  FROM LA_REVANCHA.USUARIO
							  WHERE @USERNAME = USU_USERNAME)	

	IF (@USERNAME IS NOT NULL)		
	  BEGIN	
	  
		INSERT INTO LA_REVANCHA.USUARIO(USU_USERNAME,USU_PASSWORD,USU_TIPO)
		VALUES (@USERNAME, @PASSWORD,'CLIENTE')
									  
	    SET @CLI_COD_USUARIO =(SELECT LA_REVANCHA.USUARIO.USU_CODIGO
						   FROM LA_REVANCHA.USUARIO
						   WHERE LA_REVANCHA.USUARIO.USU_USERNAME = @USERNAME )
						   
		UPDATE LA_REVANCHA.CLIENTE SET CLI_COD_USUARIO = @CLI_COD_USUARIO
														 FROM LA_REVANCHA.CLIENTE
														 JOIN inserted ON LA_REVANCHA.CLIENTE.CLI_CODIGO = inserted.CLI_CODIGO	
														 WHERE LA_REVANCHA.CLIENTE.CLI_CODIGO = inserted.CLI_CODIGO
	  END
	ELSE
		BEGIN
			raiserror ('EL USER_ID QUE SE QUIERE ASIGNAR YA EXISTE', 16, 1)
			rollback transaction
		END

					

/*Cuando se hace un instert en la tabla ROL, 
que se haga un insert en la tabla FUNCION_ROL
que para ese rol nuevo le asigne todas las funcionalidades 
(las 10 existentes) pero que las ponga todas como des-activadas */

GO
CREATE TRIGGER LA_REVANCHA.TR_ASIGNACION_DE_FUNCIONALIDADES
ON LA_REVANCHA.ROL
FOR INSERT 
AS
	DECLARE @ROL_CODIGO INT
	
	SET @ROL_CODIGO = (SELECT ROL_CODIGO	
					  FROM inserted)
					  
					   
	INSERT INTO LA_REVANCHA.FUNCION_ROL(FUNROL_ROL,FUNROL_FUNCION)
	VALUES(@ROL_CODIGO,101),
		  (@ROL_CODIGO,102),
		  (@ROL_CODIGO,103),
		  (@ROL_CODIGO,104),
		  (@ROL_CODIGO,105),
		  (@ROL_CODIGO,106),
		  (@ROL_CODIGO,107),
		  (@ROL_CODIGO,108),
		  (@ROL_CODIGO,109),
		  (@ROL_CODIGO,110)
		  
	UPDATE LA_REVANCHA.FUNCION_ROL SET FUNROL_HABILITADO = 0
												FROM inserted
												WHERE LA_REVANCHA.FUNCION_ROL.FUNROL_ROL = @ROL_CODIGO