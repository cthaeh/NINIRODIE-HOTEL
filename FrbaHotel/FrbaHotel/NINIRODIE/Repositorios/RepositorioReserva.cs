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

        public Reserva BuscarReserva(Decimal cod)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.RESERVA WHERE RES_CODIGO ='{0}'",cod);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA");

            var reservas = dataRow.ToList<Reserva>(this.DataRowToRese);
            return reservas.First();
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
            var codigo_op = Decimal.Parse(row["RESUSU_CODUSU_OPERADOR"].ToString());

            var resusu = new Resusu(codigo_res, codigo_usu, codigo_op);

            return resusu;
        }

        public Reserva DataRowToRese(DataRow row)
        {
            var codigo_hot = Decimal.Parse(row["RES_HOTREG_HOTEL"].ToString());
            var codigo_est = Decimal.Parse(row["RES_ESTRES_CODIGO"].ToString());
            var codigo_reg = Decimal.Parse(row["RES_HOTREG_REGIMEN"].ToString());
            var codigo = Decimal.Parse(row["RES_CODIGO"].ToString());

            var reserv = new Reserva(codigo,codigo_hot,codigo_reg,codigo_est );
            return reserv;
        }
        
    }
}
