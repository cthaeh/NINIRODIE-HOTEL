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

        public void InsertarHotelxRegimen(Decimal hotel, Decimal regimen)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.HOTEL_REGIMEN " +
                "(HOTREG_COD_HOTEL, HOTREG_COD_REGIMEN, HOTREG_HABILITADO)" +
                "VALUES ('{0}','{1}','{2}')", hotel, regimen, 1);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void InsertarHotel(Decimal categoria, String ciudad, String direccion,
            String nombre, String mail, String calle, String pais, Decimal telefono, 
            Decimal nro_calle, DateTime fecha)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.HOTEL " +
    "(HOT_NOMBRE, HOT_MAIL, HOT_TELEFONO, HOT_CALLE, " +
    "HOT_NRO_CALLE, HOT_ESTRELLAS, HOT_RECARGA_ESTRELLAS, HOT_CIUDAD, " +
     "HOT_PAIS,HOT_FECHA_CREACION, HOT_HABILITADO)" +
    "VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', " +
     "'{9}','{10}')", nombre, mail, telefono, calle, nro_calle,
     categoria, 100, ciudad, pais,DBTypeConverter.ToSQLDateTime(fecha),1);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
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
            var f_nac = DateTime.Parse(row["HOT_FECHA_CREACION"].ToString());

            String ciudad = "";
            if (!row["HOT_CIUDAD"].Equals(DBNull.Value))
                ciudad = row["HOT_CIUDAD"].ToString();

            var call = row["HOT_CALLE"].ToString();
            var altu = Decimal.Parse(row["HOT_NRO_CALLE"].ToString());
            var pais = row["HOT_PAIS"].ToString();

            var hab = bool.Parse(row["HOT_HABILITADO"].ToString());


            var hotel = new Hotel(codigo,nombre, meil, telef,call,altu,categoria,
                ciudad, pais, f_nac, hab,recarga);

            return hotel;
        }
    }
}
