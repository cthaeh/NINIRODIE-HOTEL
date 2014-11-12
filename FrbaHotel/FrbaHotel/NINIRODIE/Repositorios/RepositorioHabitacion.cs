using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioHabitacion
    {
        private static RepositorioHabitacion _instance;

        public static RepositorioHabitacion Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioHabitacion();
                }
                return _instance;
            }
        }
        //--------------------
        public List<Habitacion> Estadistica4(String inicio, String fin)
        {
            var query2 = String.Format(@"	SELECT TOP 5 HABITACION.*,SUM(ESTADIA.EST_DIAS_ALOJADOS) AS DIAS_HABITACION_ALOJADOS, COUNT(HABITACION_RESERVA.HABRES_COD_HABITACION) AS CANTIDAD_VECES_OCUPADA
	FROM LA_REVANCHA.HOTEL
	JOIN LA_REVANCHA.HABITACION ON HOTEL.HOT_CODIGO = HABITACION.HAB_COD_HOTEL
	JOIN LA_REVANCHA.HABITACION_RESERVA ON HABITACION.HAB_CODIGO = HABITACION_RESERVA.HABRES_COD_HABITACION
	JOIN LA_REVANCHA.RESERVA ON HABITACION_RESERVA.HABRES_COD_RESERVA = RESERVA.RES_CODIGO
	JOIN LA_REVANCHA.ESTADIA ON RESERVA.RES_CODIGO = ESTADIA.EST_COD_RESERVA
	WHERE RESERVA.RES_ESTRES_CODIGO <> 4002 AND RESERVA.RES_ESTRES_CODIGO <> 4003 AND RESERVA.RES_FECHA_DESDE >= '{0}' AND RESERVA.RES_FECHA_DESDE <= '{1}'
	GROUP BY HAB_CODIGO,HAB_NUMERO,HAB_COD_HOTEL,HAB_PISO,HAB_UBICACION,HAB_COD_TIPOHABITACION,HAB_HABILITADA,HAB_DESCRIPCION
	ORDER BY DIAS_HABITACION_ALOJADOS DESC, CANTIDAD_VECES_OCUPADA DESC", inicio, fin);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query2, "LA_REVANCHA.HABITACION");

            var habitaciones = dataRow.ToList<Habitacion>(this.DataRowToHab);
            return habitaciones;
        }
        //-----------------
        public void ModificarHabitacion(String piso, String nro, String desc, String ubi, Decimal cod_hab)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HABITACION SET HAB_PISO = '{0}', " +
                "HAB_NUMERO = '{1}', HAB_DESCRIPCION = '{2}', HAB_UBICACION = '{3}' WHERE HAB_CODIGO = '{4}' ",
                Decimal.Parse(piso), Decimal.Parse(nro), desc, ubi , cod_hab);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);

        }

        public void BajarHab(Decimal codigo, int habilitado)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HABITACION SET HAB_HABILITADA = '{0}' WHERE HAB_CODIGO = '{1}'", habilitado, codigo);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Habitacion BuscarHab(Decimal codigo)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HABITACION WHERE HAB_CODIGO = '{0}'", codigo);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HABITACION");

            var habitacion = dataRow.ToList<Habitacion>(this.DataRowToHab);
            return habitacion.First();
        }

        public Habitacion ExisteHabMod(Decimal cod_hot, Decimal nro)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HABITACION WHERE HAB_COD_HOTEL = '{0}' AND HAB_NUMERO = '{1}'", cod_hot, nro);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HABITACION");

            if (dataRow.Count > 0)
            {
                var habitacion = dataRow.ToList<Habitacion>(this.DataRowToHab);
                return habitacion.First();
            }
            else
            {
                return new Habitacion();
            }
        }

        public Decimal ExisteHab(Decimal cod_hot, Decimal nro)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HABITACION WHERE HAB_COD_HOTEL = '{0}' AND HAB_NUMERO = '{1}'", cod_hot, nro);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HABITACION");

            if (dataRow.Count > 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public List<Habitacion> BuscarHabitacion(String numero, String piso, Decimal tipo, Decimal hot)
        {
            var query = String.Format(@"Select * FROM LA_REVANCHA.HABITACION WHERE 1 = 1 ");

            if (numero != "")
            {
                query = query + "AND HAB_NUMERO = " + Decimal.Parse(numero) ;
            }
            if (piso != "")
            {
                query = query + "AND HAB_PISO = " + Decimal.Parse(piso);
            }
            if (tipo != 0)
            {
                query = query + "AND HAB_COD_TIPOHABITACION = " + tipo;
            }
            query = query + "AND HAB_COD_HOTEL = " + hot;

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HABITACION");

            var habitacion = dataRow.ToList<Habitacion>(this.DataRowToHab);
            return habitacion;

        }

        public void InsertarHabitacion(Decimal cod_hot, Decimal nro, Decimal piso,
            String desc, String ubi, Decimal tipo)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.HABITACION " +
                "(HAB_COD_HOTEL, HAB_NUMERO, HAB_PISO, HAB_UBICACION, HAB_COD_TIPOHABITACION, " +
                "HAB_HABILITADA, HAB_DESCRIPCION) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                cod_hot, nro, piso, ubi, tipo, 1, desc);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Habitacion DataRowToHab(DataRow row)
        {
            var codigo = Decimal.Parse(row["HAB_CODIGO"].ToString());
            var numero = Decimal.Parse(row["HAB_NUMERO"].ToString());
            var cod_hotel = Decimal.Parse(row["HAB_COD_HOTEL"].ToString());
            var piso = Decimal.Parse(row["HAB_PISO"].ToString());
            var ubi = row["HAB_UBICACION"].ToString();
            var tipo = Decimal.Parse(row["HAB_COD_TIPOHABITACION"].ToString());
            var hab = bool.Parse(row["HAB_HABILITADA"].ToString());
            var desc = row["HAB_DESCRIPCION"].ToString();

            var habitacion = new Habitacion(codigo, numero, cod_hotel, piso,tipo,ubi,desc,hab);
            return habitacion;
        }

        internal List<Habitacion> HabitacionesLibresEnFecha(Hotel hotel, DateTime desde, DateTime hasta)
        {
            var query = String.Format(@"SELECT HABIT.* FROM GD2C2014.LA_REVANCHA.HABITACION HABIT " +
                                       "WHERE HABIT.HAB_CODIGO NOT IN " +
                                           "(SELECT HABRES_COD_HABITACION " +
                                            "FROM GD2C2014.LA_REVANCHA.HABITACION_RESERVA WHERE " +
                                            "HABRES_COD_RESERVA IN " +
                                               "(SELECT RES_CODIGO FROM GD2C2014.LA_REVANCHA.RESERVA " +
                                                "WHERE (CAST(RES_FECHA_DESDE AS DATE) BETWEEN CAST('{1}' AS DATE) AND " +
                                                "CAST('{2}' AS DATE)) OR (CAST(RES_FECHA_HASTA AS DATE) BETWEEN " +
                                                "CAST('{1}' AS DATE) AND CAST('{2}' AS DATE))) " +
                                                "GROUP BY HABRES_COD_HABITACION) AND HABIT.HAB_COD_HOTEL = '{0}'",
                                       hotel.identificador,
                                       DBTypeConverter.ToSQLDateTime(desde), DBTypeConverter.ToSQLDateTime(hasta));

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.HABITACION");

            return dataRow.ToList<Habitacion>(this.DataRowToHab);

        }

        public Decimal CantidadPersonasParaHabitacion(Habitacion habitacion)
        {
            var query = String.Format(@"SELECT TIPHAB_CANT_PERSONAS FROM GD2C2014.LA_REVANCHA.TIPO_HABITACION " +
                                       "WHERE TIPHAB_CODIGO = '{0}'", habitacion.codigo_tipo);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.TIPO_HABITACION");

            return (dataRow.ToList<Decimal>(row => Decimal.Parse(row["TIPHAB_CANT_PERSONAS"].ToString()))).First();
        }

        internal void ReservarHabitacion(Reserva reserva, Habitacion habitacion)
        {
            var query = String.Format(@"INSERT INTO GD2C2014.LA_REVANCHA.HABITACION_RESERVA " +
                                      "(HABRES_COD_RESERVA, HABRES_COD_HABITACION) " +
                                      "VALUES ('{0}', '{1}')", reserva.identificador, habitacion.identificador);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        internal List<Habitacion> HabitacionesReserva(Reserva reserva)
        {
            var query = String.Format(@"SELECT * FROM GD2C2014.LA_REVANCHA.HABITACION " +
                                        "WHERE HAB_CODIGO IN " +
                                        "(SELECT HABRES_COD_HABITACION FROM GD2C2014.LA_REVANCHA.HABITACION_RESERVA " +
                                        "WHERE HABRES_COD_RESERVA = '{0}')", reserva.identificador);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.HABITACION");

            return dataRow.ToList<Habitacion>(this.DataRowToHab);
        }

        internal List<Habitacion> HabitacionesReservadasDisponiblesPorCambioDeFecha(Hotel hotel, 
            DateTime desdeFecha, DateTime hastaFecha, Reserva reserva)
        {
            var query = String.Format(@"SELECT * FROM GD2C2014.LA_REVANCHA.HABITACION " +
                                      "WHERE HAB_CODIGO IN (SELECT HABRES_COD_HABITACION " +
                                      "FROM GD2C2014.LA_REVANCHA.HABITACION_RESERVA WHERE " +
                                      "HABRES_COD_RESERVA IN (SELECT RES_CODIGO FROM " +
                                      "GD2C2014.LA_REVANCHA.RESERVA WHERE RES_CODIGO <> '{0}' " +
                                      "AND RES_HOTREG_HOTEL = '{1}' AND " +
                                      "(CAST(RES_FECHA_DESDE AS DATE) BETWEEN " +
                                      "CAST('{2}' AS DATE) AND CAST('{3}' AS DATE) OR " +
                                      "CAST(RES_FECHA_HASTA AS DATE) BETWEEN CAST('{2}' AS DATE) " +
                                      "AND CAST('{3}' AS DATE)))) AND HAB_COD_HOTEL = '{1}'",
                                      reserva.identificador, hotel.identificador,
                                      DBTypeConverter.ToSQLDateTime(desdeFecha), DBTypeConverter.ToSQLDateTime(hastaFecha));

            DataRowCollection dataRows = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.HABITACION");

            if (dataRows.Count > 0)
                return dataRows.ToList<Habitacion>(this.DataRowToHab);
            else
                return new List<Habitacion>();
                                      
        }

        internal void QuitarReservaDeHabitacion(Reserva reserva, Habitacion habitacionARemover)
        {
            var query = String.Format(@"DELETE FROM GD2C2014.LA_REVANCHA.HABITACION_RESERVA " +
                                      "WHERE HABRES_COD_HABITACION = '{0}' AND " +
                                      "HABRES_COD_RESERVA = '{1}'", habitacionARemover.identificador,
                                      reserva.identificador);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        internal void CancelarReserva(Reserva reserva)
        {
            var query = String.Format(@"DELETE FROM GD2C2014.LA_REVANCHA.HABITACION_RESERVA " +
                                       "WHERE HABRES_COD_RESERVA = '{0}'", reserva.identificador);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        internal List<Habitacion> HabitacionesLibresEnFechaParaReserva(Hotel hotel, Reserva reserva)
        {
            var query = String.Format(@"SELECT HABIT.* FROM GD2C2014.LA_REVANCHA.HABITACION HABIT " +
                                       "WHERE HABIT.HAB_CODIGO NOT IN " +
                                           "(SELECT HABRES_COD_HABITACION " +
                                            "FROM GD2C2014.LA_REVANCHA.HABITACION_RESERVA WHERE " +
                                            "HABRES_COD_RESERVA IN " +
                                               "(SELECT RES_CODIGO FROM GD2C2014.LA_REVANCHA.RESERVA " +
                                                "WHERE RES_CODIGO <> '{3}' AND (CAST(RES_FECHA_DESDE AS DATE) BETWEEN CAST('{1}' AS DATE) AND " +
                                                "CAST('{2}' AS DATE)) OR (CAST(RES_FECHA_HASTA AS DATE) BETWEEN " +
                                                "CAST('{1}' AS DATE) AND CAST('{2}' AS DATE))) " +
                                                "GROUP BY HABRES_COD_HABITACION) AND HABIT.HAB_COD_HOTEL = '{0}'",
                                       hotel.identificador,
                                       DBTypeConverter.ToSQLDateTime(reserva.fechaDesde), 
                                       DBTypeConverter.ToSQLDateTime(reserva.fechaHasta), reserva.identificador);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.HABITACION");

            return dataRow.ToList<Habitacion>(this.DataRowToHab);
        }
    }
}
