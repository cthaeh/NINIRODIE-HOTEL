using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.NINIRODIE.DBUtils;
using System.Data;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioEstadia
    {
        private static RepositorioEstadia _instance;

        public static RepositorioEstadia Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioEstadia();
                }
                return _instance;
            }
        }

        internal void RegistrarEstadia(Reserva reserva)
        {
            var query = String.Format(@"INSERT INTO GD2C2014.LA_REVANCHA.ESTADIA " +
                                      "(EST_COD_RESERVA, EST_FECHA_CHECK_IN) VALUES " +
                                      "('{0}', '{1}')", reserva.identificador,
                                      DBTypeConverter.ToSQLDateTime(FechaSistema.Instance.fecha));

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        internal Estadia BuscarEstadia(Reserva reserva)
        {
            var query = String.Format(@"SELECT * FROM GD2C2014.LA_REVANCHA.ESTADIA WHERE " +
                                       "EST_COD_RESERVA = '{0}'", reserva.identificador);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.ESTADIA");
            if (dataRow.Count > 0)
                return (dataRow.ToList<Estadia>(this.ObtenerEstadiaParaCheckOut)).First();
            else
                return new Estadia();
        }

        public Estadia BuscarEstadiaxCod(Decimal cod)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.ESTADIA WHERE EST_COD_ESTADIA = '{0}'", cod);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.ESTADIA");

            return (dataRow.ToList<Estadia>(this.ObtenerEstadiaParaCheckOut)).First();
        }

        public Estadia ObtenerEstadiaParaCheckOut(DataRow row)
        {
            var codigo = Decimal.Parse(row["EST_COD_ESTADIA"].ToString());
            var codigoReserva = Decimal.Parse(row["EST_COD_RESERVA"].ToString());
            DateTime desde;
            if (row["EST_FECHA_CHECK_IN"] != DBNull.Value & row["EST_FECHA_CHECK_IN"] != null)
                desde = DateTime.Parse(row["EST_FECHA_CHECK_IN"].ToString());
            else
                desde = FechaSistema.Instance.fecha;

            return new Estadia(codigo, codigoReserva, desde);
        }

        internal void RegistrarEgreso(Estadia estadia)
        {
            var query = String.Format(@"UPDATE GD2C2014.LA_REVANCHA.ESTADIA " +
                                      "SET EST_FECHA_CHECK_OUT = '{0}', EST_PRECIO = {1}, " +
                                      "EST_DIAS_ALOJADOS = '{2}', EST_DIAS_NO_ALOJADOS = '{3}' " +
                                      "WHERE EST_COD_ESTADIA = '{4}' AND EST_COD_RESERVA = '{5}'", 
                                      DBTypeConverter.ToSQLDateTime(estadia.fechaHasta),
                                      Decimal.Truncate(estadia.precio),
                                      estadia.diasAlojados, estadia.diasNoAlojados,
                                      estadia.codigo, estadia.codigoReserva);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        internal void ActualizarIngreso(Reserva reserva)
        {
            var query = String.Format(@"UPDATE GD2C2014.LA_REVANCHA.ESTADIA " +
                                      "SET EST_FECHA_CHECK_IN = '{0}' " +
                                      "WHERE EST_COD_RESERVA = '{1}'",
                                      DBTypeConverter.ToSQLDateTime(FechaSistema.Instance.fecha), 
                                      reserva.identificador);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        internal bool SeRegistroIngreso(Reserva ReservaBuscada)
        {
            var query = String.Format(@"SELECT * FROM GD2C2014.LA_REVANCHA.ESTADIA " +
                                    "WHERE EST_COD_RESERVA = '{0}' AND EST_FECHA_CHECK_IN IS NOT NULL",
                                    ReservaBuscada.identificador);

            DataRowCollection dataRows = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.ESTADIA");

            return dataRows.Count > 0;
        }
    }
}
