using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.DBUtils;
using System.Data;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioHotel
    {
        private static RepositorioHotel _instance;

        public static RepositorioHotel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioHotel();
                }
                return _instance;
            }
        }

        //---------------------------------------------------------------------

        public List<Hotel> Estadistica1(String inicio, String fin)
        {
         var query2 = String.Format(@"SELECT TOP 5 HOTEL.*
FROM LA_REVANCHA.HOTEL AS HOTEL
JOIN LA_REVANCHA.HABITACION ON HOTEL.HOT_CODIGO = HABITACION.HAB_COD_HOTEL
JOIN LA_REVANCHA.HABITACION_RESERVA ON HABITACION.HAB_CODIGO = HABITACION_RESERVA.HABRES_COD_HABITACION
JOIN LA_REVANCHA.RESERVA ON HABITACION_RESERVA.HABRES_COD_RESERVA = RESERVA.RES_CODIGO
JOIN LA_REVANCHA.CANCELACION ON RESERVA.RES_CODIGO = CANCELACION.CANC_COD_RESERVA
WHERE CANC_FECHA >= '{0}' AND CANC_FECHA <= '{1}'", inicio, fin);
            
            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query2, "LA_REVANCHA.HOTEL");

            var hoteles = dataRow.ToList<Hotel>(this.DataRowToHotel);
            return hoteles;
        }


        public List<Hotel> Estadistica4(String inicio, String fin)
        {

            var query2 = String.Format(@"SELECT TOP 5 HABITACION.HAB_CODIGO,SUM(FACTURA.FAC_DIAS_ALOJADOS) AS DIAS_HABITACION_ALOJADOS, COUNT(HABITACION_RESERVA.HABRES_COD_HABITACION) AS CANTIDAD_VECES_OCUPADA,HOTEL.*
	FROM LA_REVANCHA.HOTEL
	JOIN LA_REVANCHA.HABITACION ON HOTEL.HOT_CODIGO = HABITACION.HAB_COD_HOTEL
	JOIN LA_REVANCHA.HABITACION_RESERVA ON HABITACION.HAB_CODIGO = HABITACION_RESERVA.HABRES_COD_HABITACION
	JOIN LA_REVANCHA.RESERVA ON HABITACION_RESERVA.HABRES_COD_RESERVA = RESERVA.RES_CODIGO
	JOIN LA_REVANCHA.FACTURA ON RESERVA.RES_CODIGO = FACTURA.FAC_COD_RESERVA
	WHERE RESERVA.RES_ESTRES_CODIGO <> 4002 AND RESERVA.RES_ESTRES_CODIGO <> 4003 AND RESERVA.RES_FECHA_DESDE >= '{0}' AND RESERVA.RES_FECHA_HASTA <= '{1}'
	GROUP BY HABITACION.HAB_CODIGO, HOT_CODIGO,HOT_NOMBRE,HOT_MAIL,HOT_TELEFONO,HOT_CALLE,HOT_NRO_CALLE,
		     HOT_ESTRELLAS,HOT_RECARGA_ESTRELLAS,HOT_CIUDAD,HOT_PAIS,HOT_FECHA_CREACION,HOT_HABILITADO
	ORDER BY DIAS_HABITACION_ALOJADOS DESC, CANTIDAD_VECES_OCUPADA DESC", inicio, fin);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query2, "LA_REVANCHA.HOTEL");

            var hoteles = dataRow.ToList<Hotel>(this.DataRowToHotel);
            return hoteles;
        }

        public List<Hotel> Estadistica2(String inicio, String fin)
        {

            var query2 = String.Format(@"SELECT TOP 5 SUM(FACITEM_CANTIDAD) AS CANTIDAD_CONSUMIBLES_POR_FACTURA,HOTEL.*
FROM LA_REVANCHA.HOTEL
JOIN LA_REVANCHA.HABITACION ON HOTEL.HOT_CODIGO = HABITACION.HAB_COD_HOTEL
JOIN LA_REVANCHA.HABITACION_RESERVA ON HABITACION.HAB_CODIGO = HABITACION_RESERVA.HABRES_COD_HABITACION
JOIN LA_REVANCHA.RESERVA ON HABITACION_RESERVA.HABRES_COD_RESERVA = RESERVA.RES_CODIGO
JOIN LA_REVANCHA.FACTURA ON RESERVA.RES_CODIGO = FACTURA.FAC_COD_RESERVA
JOIN LA_REVANCHA.FACTURA_ITEM ON FACTURA.FAC_CODIGO = FACTURA_ITEM.FACITEM_COD_FACTURA
WHERE FAC_FECHA >= '{0}' AND FAC_FECHA	<= '{1}'
GROUP BY FACITEM_COD_FACTURA, FACITEM_CANTIDAD,HOT_CODIGO,HOT_NOMBRE,HOT_MAIL,HOT_TELEFONO,HOT_CALLE,HOT_NRO_CALLE,
		 HOT_ESTRELLAS,HOT_RECARGA_ESTRELLAS,HOT_CIUDAD,HOT_PAIS,HOT_FECHA_CREACION,HOT_HABILITADO
ORDER BY CANTIDAD_CONSUMIBLES_POR_FACTURA DESC", inicio, fin);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query2, "LA_REVANCHA.HOTEL");

            var hoteles = dataRow.ToList<Hotel>(this.DataRowToHotel);
            return hoteles;
        }

        // ---------------------------------------------------------------------

        public void QuitarHotel(Decimal cod_usu, Decimal cod_hot)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HOTEL_USUARIO SET HOTCERR_HABILITADO = '{0}' " +
                "WHERE HOTCERR_COD_HOTEL = '{1}' AND HOTUSU_COD_USUARIO = '{2}'", 0, cod_hot, cod_usu);
            
            SQLUtils.EjecutarConsultaConEfectoDeLado(query);

        }

        public void CerrarHotel(Decimal cod_hot, int dias, DateTime inicio, DateTime fin, String motivo)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.HOTEL_CERRADO " +
                "(HOTCERR_COD_HOTEL, HOTCERR_CANT_DIAS_CERRADO, HOTCERR_FECHA_DESDE, HOTCERR_FECHA_HASTA, HOTCERR_MOTIVO)" +
                "VALUES('{0}','{1}','{2}','{3}','{4}')", cod_hot, dias, DBTypeConverter.ToSQLDateTime(inicio), DBTypeConverter.ToSQLDateTime(fin), motivo);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void LimpiarHotelRegimen(Decimal cod_hotel)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HOTEL_REGIMEN SET HOTREG_HABILITADO = '{0}' " + 
                "WHERE HOTREG_COD_HOTEL = '{1}'", 0, cod_hotel);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void Vincular(Decimal cod_usu, Decimal cod_hotel)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.HOTEL_USUARIO " +
    "(HOTCERR_COD_HOTEL, HOTCERR_HABILITADO, HOTUSU_COD_USUARIO)" +
    "VALUES ('{0}','{1}','{2}')", cod_hotel, 1, cod_usu);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void ActualizarVinculo(Decimal cod_usu, Decimal cod_hotel)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HOTEL_USUARIO SET HOTCERR_HABILITADO = '{0}' WHERE HOTCERR_COD_HOTEL = '{1}' AND HOTUSU_COD_USUARIO = '{2}'",
                1, cod_hotel, cod_usu);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Hotel ExisteHotelMod(String nombre)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HOTEL WHERE HOT_NOMBRE = '{0}'", nombre);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HOTEL");

            if (dataRow.Count > 0)
            {
                var hoteles = dataRow.ToList<Hotel>(this.DataRowToHotel);
                return hoteles.First();
            }
            else
            {
                return new Hotel();
            }
        }

        public Decimal ExisteHotel(String nombre)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HOTEL WHERE HOT_NOMBRE = '{0}'", nombre);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HOTEL");

            if (dataRow.Count > 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public void ModificarHotel(Decimal telefono, Decimal categoria, String ciudad,
            String calle, String nombre, Decimal nro_calle, String pais, Decimal recargo, Decimal cod_hotel, String mail)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HOTEL SET HOT_TELEFONO = '{0}', " +
                "HOT_ESTRELLAS = '{1}', HOT_CIUDAD = '{2}', HOT_CALLE = '{3}', " +
                "HOT_NOMBRE = '{4}', HOT_NRO_CALLE = '{5}', HOT_MAIL = '{9}', HOT_PAIS = '{6}', HOT_RECARGA_ESTRELLAS = '{7}' WHERE HOT_CODIGO = '{8}'",
                telefono, categoria, ciudad, calle, nombre, nro_calle, pais, recargo, cod_hotel, mail);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Decimal TieneHotel(Decimal cod_usu, Decimal cod_hot)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HOTEL_USUARIO WHERE HOTCERR_COD_HOTEL = '{0}' AND HOTUSU_COD_USUARIO = '{1}'",
                cod_hot, cod_usu);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HOTEL_USUARIO");

            if (dataRow.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<Hotemp> BuscarHotelesEmp(Decimal cod_usu)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HOTEL_USUARIO WHERE HOTCERR_HABILITADO = '{0}' AND HOTUSU_COD_USUARIO = '{1}'", 1, cod_usu);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HOTEL_USUARIO");

            var hoteles = dataRow.ToList<Hotemp>(this.DataRowToHotemp);
            return hoteles;
        }

        public List<Hotel> BuscarHoteles()
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HOTEL WHERE HOT_HABILITADO = '{0}'", 1);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HOTEL");

            var hoteles = dataRow.ToList<Hotel>(this.DataRowToHotel);
            return hoteles;
        }

        public void BajarHotelEmp(Decimal codigo, Decimal habilitado)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HOTEL_USUARIO SET HOTCERR_HABILITADO = " +
                "'{0}' WHERE HOTCERR_COD_HOTEL = '{1}'", habilitado, codigo);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void BajarHotel(Decimal codigo, Decimal habilitado)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HOTEL SET HOT_HABILITADO = " +
"'{0}' WHERE HOT_CODIGO = '{1}'", habilitado, codigo);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public List<Hotel> BuscarHotelD(Decimal categoria, String ciudad, String nombre,
            String pais)
        {
            var query = String.Format(@"Select * FROM LA_REVANCHA.HOTEL WHERE 1 = 1 ");

            if (categoria != 1000)
            {
                query = query + "AND HOT_ESTRELLAS = " + categoria;
            }
            if (nombre != "")
            {
                query = query + "AND HOT_NOMBRE = '" + nombre + "' ";
            }
            if (ciudad != "")
            {
                query = query + "AND HOT_CIUDAD = ' " + ciudad + "' ";
            }
            if (pais != "")
            {
                query = query + "AND HOT_PAIS = '" + pais + "' ";
            }

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HOTEL");

            var hoteles = dataRow.ToList<Hotel>(this.DataRowToHotel);
            return hoteles;
        }

        public void ModificarHotelxRegimen(Decimal hotel, Decimal hab, Decimal regimen)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HOTEL_REGIMEN SET HOTREG_HABILITADO = '{0}' " +
                "WHERE HOTREG_COD_HOTEL = '{1}' and HOTREG_COD_REGIMEN = '{2}'",
                hab, hotel, regimen);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void InsertarHotelxRegimen(Decimal hotel,Decimal hab, Decimal regimen)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.HOTEL_REGIMEN " +
                "(HOTREG_COD_HOTEL, HOTREG_COD_REGIMEN, HOTREG_HABILITADO)" +
                "VALUES ('{0}','{1}','{2}')", hotel, regimen, hab);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void InsertarHotel(Decimal categoria, String ciudad, String direccion,
            String nombre, String mail, String calle, String pais, Decimal telefono, 
            Decimal nro_calle, DateTime fecha, Decimal recargo)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.HOTEL " +
    "(HOT_NOMBRE, HOT_MAIL, HOT_TELEFONO, HOT_CALLE, " +
    "HOT_NRO_CALLE, HOT_ESTRELLAS, HOT_RECARGA_ESTRELLAS, HOT_CIUDAD, " +
     "HOT_PAIS,HOT_FECHA_CREACION, HOT_HABILITADO)" +
    "VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', " +
     "'{9}','{10}')", nombre, mail, telefono, calle, nro_calle,
     categoria, recargo, ciudad, pais,DBTypeConverter.ToSQLDateTime(fecha),1);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }


        public Hotel BuscarHotelxId(Decimal id)
        {
            var query = String.Format(@"Select * FROM LA_REVANCHA.HOTEL WHERE HOT_CODIGO = '{0}'", id);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HOTEL");

            var hoteles = dataRow.ToList<Hotel>(this.DataRowToHotel);
            return hoteles.First();
        }

        public Hotel BuscarHotel(String nombre)
        {
            var query = String.Format(@"Select * FROM LA_REVANCHA.HOTEL WHERE HOT_NOMBRE = '{0}'", nombre);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HOTEL");

            var hoteles = dataRow.ToList<Hotel>(this.DataRowToHotel);
            return hoteles.First();
        }

        public void InsertarCliente(Cliente cliente)
        {

            var query = String.Format(@"INSERT INTO LA_REVANCHA.CLIENTE " +
                "(CLI_TIPO_IDENTIFICACION, CLI_NUMERO_IDENTIFICACION, CLI_NOMBRE, CLI_APELLIDO, " +
                "CLI_TELEFONO, CLI_MAIL, CLI_FECHA_NACIMIENTO, CLI_CALLE, " +
                 "CLI_PISO,CLI_DEPARTAMENTO, CLI_LOCALIDAD, CLI_NACIONALIDAD, " +
                 "CLI_PAIS_ORIGEN, CLI_NRO_CALLE)" +
                "VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', " +
                 "'{9}','{10}','{11}','{12}','{13}')", cliente.tipo_documento,
                 cliente.numero_documento, cliente.nombre, cliente.apellido, cliente.telefono,
                 cliente.mail, DBTypeConverter.ToSQLDateTime(cliente.nacimiento), cliente.calle,
                 cliente.piso, cliente.departamento, cliente.localidad, cliente.nacionalidad,
                 cliente.pais, cliente.nro_calle);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);

        }

        public Hotemp DataRowToHotemp(DataRow row)
        {
            var codigo_hot = Decimal.Parse(row["HOTCERR_COD_HOTEL"].ToString());
            var codigo_usu = Decimal.Parse(row["HOTUSU_COD_USUARIO"].ToString());
            var habilitado = bool.Parse(row["HOTCERR_HABILITADO"].ToString());

            var hote = new Hotemp(codigo_hot, codigo_usu, habilitado);
            return hote;
        }

        public Hotel DataRowToHotel(DataRow row)
        {
            var codigo = Decimal.Parse(row["HOT_CODIGO"].ToString());
            var nombre = row["HOT_NOMBRE"].ToString();
            var categoria = Decimal.Parse(row["HOT_ESTRELLAS"].ToString());
            var recarga = Decimal.Parse(row["HOT_RECARGA_ESTRELLAS"].ToString());

            Decimal telef = 0;
            if (!row["HOT_TELEFONO"].Equals(DBNull.Value))
                telef = Decimal.Parse(row["HOT_TELEFONO"].ToString());

            var meil = row["HOT_MAIL"].ToString();
           // var f_nac = DateTime.Parse("07/10/2014 09:56:50 p.m.");
           
            String ciudad = "";
            if (!row["HOT_CIUDAD"].Equals(DBNull.Value))
                ciudad = row["HOT_CIUDAD"].ToString();

            var call = row["HOT_CALLE"].ToString();
            var altu = Decimal.Parse(row["HOT_NRO_CALLE"].ToString());
            var pais = row["HOT_PAIS"].ToString();

            var hab = bool.Parse(row["HOT_HABILITADO"].ToString());


            var hotel = new Hotel(codigo,nombre, meil, telef,call,altu,categoria,
                ciudad, pais, hab,recarga);

            return hotel;
        }
    }
}
