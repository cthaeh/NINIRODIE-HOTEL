using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioReserva
    {
        private static RepositorioReserva _instance;

        public static RepositorioReserva Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioReserva();
                }
                return _instance;
            }
        }
        public Decimal BuscarMontoEstadia(Decimal cod_res)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.ESTADIA WHERE EST_COD_RESERVA = '{0}'", cod_res);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.ESTADIA");

            return Decimal.Parse(dataRow[0]["EST_PRECIO"].ToString());
        }

        public List<Resusu> BuscarReservasDeUsu(Decimal cod_usu)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.RESERVA_USUARIO WHERE RESUSU_CODUSU_HUESPED = '{0}'", cod_usu);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA_USUARIO");

            var reservas = dataRow.ToList<Resusu>(this.DataRowToResu);
            return reservas;
        }

        public Decimal BuscarUsuario(Decimal reserva)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.RESERVA_USUARIO WHERE RESUSU_COD_RESERVA = '{0}'", reserva);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA_USUARIO");

            var reservas = dataRow.ToList<Resusu>(this.DataRowToResu);
            return reservas.First().identificador_usuario;
        }

        public List<Decimal> BuscarHabitaciones(Decimal reserva)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HABITACION_RESERVA WHERE HABRES_COD_RESERVA = '{0}'", reserva);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HABITACION_RESERVA");

            var codigos = dataRow.ToList<Decimal>(this.dataRowToCod);
            return codigos;
        }

        public Decimal dataRowToCod(DataRow row)
        {
            var cod_hab = Decimal.Parse(row["HABRES_COD_HABITACION"].ToString());
            return cod_hab;
        }

        public List<Reserva> BuscarReservas()
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.RESERVA");

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA");

            var reservas = dataRow.ToList<Reserva>(this.DataRowToRese);
            return reservas;
        }

        public Decimal BuscarHabitacion(Decimal cod_reserva)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HABITACION_RESERVA WHERE HABRES_COD_RESERVA ='{0}'", cod_reserva);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA");

            var reservas = dataRow.ToList<HabRes>(this.DataRowToHabRes);
            return reservas.First().identificador_habitacion;
        }

        public Reserva BuscarReserva2(Decimal cod)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.RESERVA WHERE RES_CODIGO = '{0}'", cod);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA");

            if (dataRow.Count == 0)
            {
                return new Reserva();
            }
            else
            {
                var reservas = dataRow.ToList<Reserva>(this.DataRowToRese);
                return reservas.First();
            }
        }

        public Reserva BuscarReserva(Decimal cod)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.RESERVA WHERE RES_CODIGO = '{0}' " +
                                        "AND RES_CODIGO NOT IN (SELECT CANC_COD_RESERVA FROM " +
                                        "GD2C2014.LA_REVANCHA.CANCELACION WHERE CANC_COD_RESERVA = '{0}')",cod);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA");

			if (dataRow.Count == 0)
            {
				return new Reserva();
			}
			else
			{		
				var reservas = dataRow.ToList<Reserva>(this.DataRowToRese);
				return reservas.First();
			}
        }

        public HabRes DataRowToHabRes(DataRow row)
        {
            var cod_res = Decimal.Parse(row["HABRES_COD_RESERVA"].ToString());
            var cod_hab = Decimal.Parse(row["HABRES_COD_HABITACION"].ToString());

            var habr = new HabRes(cod_res, cod_hab);

            return habr;
        }

        public Resusu DataRowToResu(DataRow row)
        {
            var codigo_res = Decimal.Parse(row["RESUSU_COD_RESERVA"].ToString());
            var codigo_usu = Decimal.Parse(row["RESUSU_CODUSU_HUESPED"].ToString());
            Decimal codigo_op;
            if (row["RESUSU_CODUSU_OPERADOR"] != null & row["RESUSU_CODUSU_OPERADOR"] != DBNull.Value)
                codigo_op = Decimal.Parse(row["RESUSU_CODUSU_OPERADOR"].ToString());
            else
                codigo_op = 0;
            var resusu = new Resusu(codigo_res, codigo_usu, codigo_op);

            return resusu;
        }

        public Reserva DataRowToRese(DataRow row)
        {
            var codigo_hot = Decimal.Parse(row["RES_HOTREG_HOTEL"].ToString());
            var codigo_est = Decimal.Parse(row["RES_ESTRES_CODIGO"].ToString());
            var codigo_reg = Decimal.Parse(row["RES_HOTREG_REGIMEN"].ToString());
            var codigo = Decimal.Parse(row["RES_CODIGO"].ToString());
            var desde = DateTime.Parse(row["RES_FECHA_DESDE"].ToString());
            var hasta = DateTime.Parse(row["RES_FECHA_HASTA"].ToString());

            var reserv = new Reserva(codigo,codigo_hot,codigo_reg,codigo_est, desde, hasta);
            return reserv;
        }


        internal void GenerarReserva(Reserva reserva)
        {
            var ultimaReserva = String.Format(@"SELECT TOP 1 RES_CODIGO FROM GD2C2014.LA_REVANCHA.RESERVA " +
                                                "ORDER BY RES_CODIGO DESC");

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(ultimaReserva, "GD2C2014.LA_REVANCHA.RESERVA");

            reserva.identificador = (dataRow.ToList<Decimal>(row => Decimal.Parse(row["RES_CODIGO"].ToString()))).First() + 1;

            var query = String.Format(@"INSERT INTO GD2C2014.LA_REVANCHA.RESERVA " +
                                        "(RES_CODIGO, RES_FECHA_CARGA, RES_FECHA_DESDE, RES_FECHA_HASTA, RES_HOTREG_HOTEL, " +
                                        "RES_HOTREG_REGIMEN, RES_ESTRES_CODIGO) " +
                                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", reserva.identificador,
                                        DBTypeConverter.ToSQLDateTime(FechaSistema.Instance.fecha),
                                        DBTypeConverter.ToSQLDateTime(reserva.fechaDesde),
                                        DBTypeConverter.ToSQLDateTime(reserva.fechaHasta),
                                        reserva.identificador_hotel, reserva.identificador_regimen, reserva.identificador_estado);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        internal void RealizarCancelacion(Cancelacion cancelacion)
        {
            var query = String.Format(@"INSERT INTO GD2C2014.LA_REVANCHA.CANCELACION " +
                                    "(CANC_COD_RESERVA, CANC_MOTIVO, CANC_FECHA, CANC_COD_USUARIO) " +
                                    "VALUES ('{0}', '{1}', '{2}', '{3}')", cancelacion.codigoReserva,
                                    cancelacion.motivo, DBTypeConverter.ToSQLDateTime(FechaSistema.Instance.fecha),
                                    cancelacion.codigoUsuario);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);

            var consultaCodigoCancelacion = String.Format(@"SELECT TOP 1 CANC_CODIGO FROM GD2C2014.LA_REVANCHA.CANCELACION " +
                                                        "ORDER BY CANC_CODIGO DESC");

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(consultaCodigoCancelacion,
                                                                        "GD2C2014.LA_REVANCHA.CANCELACION");

            cancelacion.codigo = (dataRow.ToList<Decimal>(row => Decimal.Parse(row["CANC_CODIGO"].ToString()))).First();
        }

        internal void ActualizarEstadoReservaACancelada(Usuario usuario, Cancelacion cancelacion)
        {
            var query = String.Format(@"UPDATE GD2C2014.LA_REVANCHA.RESERVA " +
                                    "SET RES_ESTRES_CODIGO = '{0}' " +
                                    "WHERE RES_CODIGO = '{1}'", usuario.tipo == "CLIENTE" ? 
                                        new Decimal(4003) : new Decimal(4002) ,cancelacion.codigoReserva);
            
            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        internal Cancelacion VerificarCancelacion(Decimal cod, Usuario user)
        {
            var query = String.Format(@"SELECT * FROM GD2C2014.LA_REVANCHA.CANCELACION " +
                                    "WHERE CANC_COD_RESERVA = '{0}' AND CANC_COD_RESERVA IN " +
                                    "(SELECT RESUSU_COD_RESERVA FROM GD2C2014.LA_REVANCHA.RESERVA_USUARIO " +
                                    "WHERE RESUSU_CODUSU_HUESPED = '{1}')", cod, user.codigo);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.CANCELACION");

            Cancelacion cancelacion = new Cancelacion(-1);

            if (dataRow.Count > 0)
                cancelacion = (dataRow.ToList<Cancelacion>(this.dataRowToCancelacion)).First();

            return cancelacion;
        }

        private Cancelacion dataRowToCancelacion(DataRow row)
        {
            var codigo = Decimal.Parse(row["CANC_CODIGO"].ToString());
            var codigoReser = Decimal.Parse(row["CANC_COD_RESERVA"].ToString());
            var codigoUser = Decimal.Parse(row["CANC_COD_USUARIO"].ToString());
            var fecha = DateTime.Parse(row["CANC_FECHA"].ToString());
            var motive= row["CANC_MOTIVO"].ToString();

            return new Cancelacion(codigo, motive, codigoReser, codigoUser, fecha);
        }

        internal Reserva BuscarReservaDeUsuario(decimal codigoReserva, Usuario usuario)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.RESERVA WHERE RES_CODIGO = '{0}' " +
                                        "AND RES_CODIGO NOT IN (SELECT CANC_COD_RESERVA FROM " +
                                        "GD2C2014.LA_REVANCHA.CANCELACION WHERE CANC_COD_RESERVA = '{0}') " +
                                        "AND RES_CODIGO IN (SELECT RESUSU_COD_RESERVA FROM " +
                                        "GD2C2014.LA_REVANCHA.RESERVA_USUARIO WHERE RESUSU_CODUSU_HUESPED = '{1}')", 
                                        codigoReserva, usuario.codigo);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA");

            var reservas = dataRow.ToList<Reserva>(this.DataRowToRese);

            if (reservas.Count() > 0)
                return reservas.First();
            else
                return new Reserva(-1);
        }

        internal void ActualizarEstadoReserva(Reserva reserva, Decimal codigoACambiar)
        {
            var query = String.Format(@"UPDATE GD2C2014.LA_REVANCHA.RESERVA " +
                                    "SET RES_ESTRES_CODIGO = '{0}' " +
                                    "WHERE RES_CODIGO = '{1}'", codigoACambiar, reserva.identificador);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        internal void ModificarReserva(Reserva reserva, DateTime fechaDesde, DateTime fechaHasta, Regimen regimen, Decimal codigoModificacion)
        {
            var query = String.Format(@"UPDATE GD2C2014.LA_REVANCHA.RESERVA " +
                                      "SET RES_FECHA_DESDE = '{0}', RES_FECHA_HASTA = '{1}', " +
                                      "RES_HOTREG_REGIMEN = '{2}', RES_ESTRES_CODIGO = '{3}' "+
                                      "WHERE RES_CODIGO = '{4}'", DBTypeConverter.ToSQLDateTime(fechaDesde),
                                      DBTypeConverter.ToSQLDateTime(fechaHasta), regimen.identificador, codigoModificacion,
                                      reserva.identificador);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }
    }
}
