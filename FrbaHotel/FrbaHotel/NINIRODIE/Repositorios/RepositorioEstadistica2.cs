using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioEstadistica2
    {
        private static RepositorioEstadistica2 _instance;

        public static RepositorioEstadistica2 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioEstadistica2();
                }
                return _instance;
            }
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

            var hoteles = dataRow.ToList<Hotel>(this.DataRowToEst2);
            return hoteles;
        }

        public Hotel DataRowToEst2(DataRow row)
        {
            var codigo = Decimal.Parse(row["HOT_CODIGO"].ToString());
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
