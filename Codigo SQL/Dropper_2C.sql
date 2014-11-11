GO
USE [GD2C2014]
GO


--BORRAR TRIGGERS
DROP TRIGGER LA_REVANCHA.TR_AUT_USERNAME
DROP TRIGGER LA_REVANCHA.TR_ASIGNACION_DE_FUNCIONALIDADES
DROP TRIGGER LA_REVANCHA.TR_CALCULADOR_DE_DIAS

--BORRAR TABLAS--
DROP VIEW LA_REVANCHA.VIEW_HOTEL_REGIMEN
DROP VIEW LA_REVANCHA.VIEW_CLIENTES_MAESTRA
DROP TABLE LA_REVANCHA.FACTURA_ITEM
DROP TABLE LA_REVANCHA.FACTURA
DROP TABLE LA_REVANCHA.ESTADIA
DROP TABLE LA_REVANCHA.RESERVA_USUARIO
DROP TABLE LA_REVANCHA.HABITACION_RESERVA
DROP TABLE LA_REVANCHA.CANCELACION
DROP TABLE LA_REVANCHA.RESERVA
DROP TABLE LA_REVANCHA.ESTADO_RESERVA
DROP TABLE LA_REVANCHA.FORMA_PAGO
DROP TABLE LA_REVANCHA.CONSUMBILES
DROP TABLE LA_REVANCHA.HOTEL_USUARIO
DROP TABLE LA_REVANCHA.HOTEL_CERRADO
DROP TABLE LA_REVANCHA.HABITACION
DROP TABLE LA_REVANCHA.TIPO_HABITACION
DROP TABLE LA_REVANCHA.HOTEL_REGIMEN
DROP TABLE LA_REVANCHA.HOTEL
DROP TABLE LA_REVANCHA.REGIMEN
DROP TABLE LA_REVANCHA.FUNCION_ROL
DROP TABLE LA_REVANCHA.FUNCION
DROP TABLE LA_REVANCHA.USUARIO_ROL
DROP TABLE LA_REVANCHA.ROL
DROP TABLE LA_REVANCHA.PERSONAL
DROP TABLE LA_REVANCHA.CLIENTE
DROP TABLE LA_REVANCHA.USUARIO


DROP SCHEMA LA_REVANCHA