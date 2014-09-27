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
			 [USU_HABILITADO] [BIT],
			 [USU_BLOQUEADO] [BIT],
PRIMARY KEY CLUSTERED (USU_CODIGO),
)

GO
CREATE TABLE [LA_REVANCHA].[CLIENTE](
			 [CLI_CODIGO][NUMERIC](18,0),
			 [CLI_COD_USUARIO][NUMERIC](18,0),
			 [CLI_NOMBRE][NVARCHAR](255),
			 [CLI_APELLIDO][NVARCHAR](255),
			 [CLI_NUMERO_IDENTIFICACION][NUMERIC](18,0),
			 [CLI_TIPO_IDENTIFICACIION][NVARCHAR](255),
			 [CLI_MAIL][NVARCHAR](255) UNIQUE,
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
			 [PER_CODIGO][NUMERIC](18,0),
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
			 [FUN_CODIGO][INT],
	         [FUN_DESCRIPCION][NVARCHAR](255),
PRIMARY KEY CLUSTERED (FUN_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[FUNCION_ROL](
	         [FUNROL_ROL][INT],
    	     [FUNROL_FUNCION][INT],
FOREIGN KEY (FUNROL_ROL) REFERENCES LA_REVANCHA.ROL(ROL_CODIGO),
FOREIGN KEY (FUNROL_FUNCION) REFERENCES LA_REVANCHA.FUNCION(FUN_CODIGO)	
)

GO
CREATE TABLE [LA_REVANCHA].[REGIMEN](
			 [REG_CODIGO][NUMERIC](18,0),
			 [REG_DESCRIPCION][NVARCHAR](255),
			 [REG_PRECIO][NUMERIC](18,2),
			 [REG_HABILITADO][BIT] default 1, -- ES PARA LA BAJA LOGICA  - HABILITADO POR DEFECTO
PRIMARY KEY CLUSTERED (REG_CODIGO)
)

GO 
CREATE TABLE [LA_REVANCHA].[HOTEL](
			 [HOT_CODIGO][NUMERIC](18,0),
			 [HOT_NOMBRE][NVARCHAR](255),
			 [HOT_MAIL][NVARCHAR](255),
			 [HOT_TELEFONO][NUMERIC](18,0),
			 [HOT_CALLE][NVARCHAR](255),
			 [HOT_NRO_CALLE][NUMERIC](18,0),
			 [HOT_ESTRELLAS][NUMERIC](18,0),
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
PRIMARY KEY CLUSTERED (TIPHAB_CODIGO)
)	
			 
GO
CREATE TABLE [LA_REVANCHA].[HABITACION](
			 [HAB_CODIGO][NUMERIC](18,0) IDENTITY (20,20),
			 [HAB_NUMERO][NUMERIC](18,0),
			 [HAB_COD_HOTEL][NUMERIC](18,0),
			 [HAB_PISO][NUMERIC](18,0),
			 [HAB_UBICACION][NVARCHAR](50),
			 [HAB_COD_TIPOHABITACION][NUMERIC](18,0),
			 [HAB_HABILITADA][BIT],
PRIMARY KEY CLUSTERED(HAB_CODIGO), 
FOREIGN KEY (HAB_COD_HOTEL) REFERENCES LA_REVANCHA.HOTEL(HOT_CODIGO),
FOREIGN KEY (HAB_COD_TIPOHABITACION) REFERENCES LA_REVANCHA.TIPO_HABITACION(TIPHAB_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[HOTEL_CERRADO](
			 [HOTCERR_CODIGO][NUMERIC](18,0),
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
			 [PAGO_CODIGO][NUMERIC](18,0),
			 [PAGO_DESCRIPCION][NVARCHAR](255),
			 [PAGO_NOMBRE][NVARCHAR](255),
			 [PAGO_APELLIDO][NVARCHAR](255),
			 [PAGO_NRO_TARJETA][NUMERIC](18,0),
PRIMARY KEY CLUSTERED (PAGO_CODIGO)
)	

GO
CREATE TABLE [LA_REVANCHA].[ESTADO_RESERVA](
			 [ESTRES_CODIGO][NUMERIC](18,0),
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
			 [RES_ESTRES_CODIGO][NUMERIC](18,0),
PRIMARY KEY CLUSTERED (RES_CODIGO),
FOREIGN KEY (RES_HOTREG_HOTEL,RES_HOTREG_REGIMEN) REFERENCES LA_REVANCHA.HOTEL_REGIMEN(HOTREG_COD_HOTEL,HOTREG_COD_REGIMEN),
FOREIGN KEY (RES_ESTRES_CODIGO) REFERENCES LA_REVANCHA.ESTADO_RESERVA(ESTRES_CODIGO)
)
			
			
GO 
CREATE TABLE [LA_REVANCHA].[CANCELACION](
				[CANC_CODIGO][NUMERIC](18,0),
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
			 [FAC_COD_FORMA_PAGO][NUMERIC](18,0),
			 [FAC_COD_RESERVA][NUMERIC](18,0),	 
			 [FAC_TOTAL][NUMERIC](18,2),
PRIMARY KEY CLUSTERED (FAC_CODIGO),
FOREIGN KEY (FAC_COD_FORMA_PAGO) REFERENCES LA_REVANCHA.FORMA_PAGO(PAGO_CODIGO),
FOREIGN KEY (FAC_COD_RESERVA) REFERENCES LA_REVANCHA.RESERVA(RES_CODIGO)
)

GO
CREATE TABLE [LA_REVANCHA].[FACTURA_CONSUMIBLE](
			 [FACCON_COD_FACTURA][NUMERIC](18,0),
			 [FACCON_COD_CONSUMIBLE][NUMERIC](18,0),
			 [FACCON_CANTIDAD][NUMERIC](18,0)
PRIMARY KEY CLUSTERED (FACCON_COD_FACTURA,FACCON_COD_CONSUMIBLE),
FOREIGN KEY (FACCON_COD_FACTURA) REFERENCES LA_REVANCHA.FACTURA(FAC_CODIGO),
FOREIGN KEY (FACCON_COD_CONSUMIBLE) REFERENCES LA_REVANCHA.CONSUMBILES(CONS_CODIGO)
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

INSERT INTO LA_REVANCHA.TIPO_HABITACION(TIPHAB_CODIGO,TIPHAB_DESCRIPCION,TIPHAB_PORCENTUAL)
SELECT DISTINCT(Habitacion_Tipo_Codigo), Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra
WHERE Habitacion_Tipo_Codigo IS NOT NULL



--DATOS DE LOS HOTELES.
INSERT INTO LA_REVANCHA.HOTEL(HOT_CALLE, HOT_NRO_CALLE, HOT_CIUDAD,
 HOT_ESTRELLAS,HOT_RECARGA_ESTRELLAS)
select distinct Hotel_Calle,Hotel_Nro_Calle,Hotel_Ciudad,Hotel_CantEstrella,Hotel_Recarga_Estrella
from gd_esquema.Maestra


