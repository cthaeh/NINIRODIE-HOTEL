using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioEstadistica3
    {
        private static RepositorioEstadistica3 _instance;

        public static RepositorioEstadistica3 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioEstadistica3();
                }
                return _instance;
            }
        }

        public List<Hotel> Estadistica3(String inicio, String fin)
        {

            var query2 = String.Format(@"SELECT TOP 5 SUM(HOTEL_CERRADO.HOTCERR_CANT_DIAS_CERRADO) AS CANTIDAD_DE_DIAS_CERRADO, HOTEL_CERRADO.HOTCERR_COD_HOTEL,HOT_NOMBRE,HOT_MAIL,HOT_TELEFONO,HOT_CALLE,HOT_NRO_CALLE,
	             HOT_ESTRELLAS,HOT_RECARGA_ESTRELLAS,HOT_CIUDAD,HOT_PAIS,HOT_FECHA_CREACION,HOT_HABILITADO
	FROM LA_REVANCHA.HOTEL_CERRADO, LA_REVANCHA.HOTEL
	WHERE HOTCERR_COD_HOTEL = HOTEL.HOT_CODIGO AND LA_REVANCHA.HOTEL_CERRADO.HOTCERR_FECHA_DESDE >= '{0}'  AND LA_REVANCHA.HOTEL_CERRADO.HOTCERR_FECHA_HASTA <= '{1}'
	GROUP BY HOTEL_CERRADO.HOTCERR_COD_HOTEL, HOTEL_CERRADO.HOTCERR_COD_HOTEL, HOT_NOMBRE,HOT_MAIL,HOT_TELEFONO,HOT_CALLE,HOT_NRO_CALLE,
		     HOT_ESTRELLAS,HOT_RECARGA_ESTRELLAS,HOT_CIUDAD,HOT_PAIS,HOT_FECHA_CREACION,HOT_HABILITADO
	ORDER BY CANTIDAD_DE_DIAS_CERRADO DESC", inicio, fin);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query2, "LA_REVANCHA.HOTEL");

            var hoteles = dataRow.ToList<Hotel>(this.DataRowToEst3);
            return hoteles;
        }

        public Hotel DataRowToEst3(DataRow row)
        {
            var codigo = Decimal.Parse(row["HOTCERR_COD_HOTEL"].ToString());
            var nombre = row["HOT_NOMBRE"].ToString();
            var categoria = Decimal.Parse(row["HOT_ESTRELLAS"].ToString());
            var recarga = Decimal.Parse(row["HOT_RECARGA_ESTRELLAS"].ToString());

            Decimal telef = 0;
            if (!row["HOT_TELEFONO"].Equals(DBNull.Value))
                telef = Decimal.Parse(row["HOT_TELEFONO"].ToString());

            var meil = row["HOT_MAIL"].ToString();
            var f_nac = DateTime.Parse("07/10/2014 09:56:50 p.m.");

            String ciudad = "";
            if (!row["HOT_CIUDAD"].Equals(DBNull.Value))
                ciudad = row["HOT_CIUDAD"].ToString();

            var call = row["HOT_CALLE"].ToString();
            var altu = Decimal.Parse(row["HOT_NRO_CALLE"].ToString());
            var pais = row["HOT_PAIS"].ToString();

            var hab = bool.Parse(row["HOT_HABILITADO"].ToString());


            var hotel = new Hotel(codigo, nombre, meil, telef, call, altu, categoria,
                ciudad, pais, f_nac, hab, recarga);

            return hotel;
        }
    }
}
