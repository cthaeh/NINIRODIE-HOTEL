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

        public Resusu DataRowToResu(DataRow row)
        {
            var codigo_res = Decimal.Parse(row["RESUSU_COD_RESERVA"].ToString());
            var codigo_usu = Decimal.Parse(row["RESUSU_CODUSU_HUESPED"].ToString());
            var codigo_op = Decimal.Parse(row["RESUSU_CODUSU_OPERADOR"].ToString());
            var f_ent = DateTime.Parse("07/10/2014 09:56:50 p.m.");
            var f_sal = DateTime.Parse("07/10/2014 09:56:50 p.m.");

            var resusu = new Resusu(codigo_res, f_ent, f_sal, codigo_usu, codigo_op);

            return resusu;
        }

        public Reserva DataRowToRese(DataRow row)
        {
            var codigo_hot = Decimal.Parse(row["RES_HOTREG_HOTEL"].ToString());
            var codigo_est = Decimal.Parse(row["RES_ESTRES_CODIGO"].ToString());
            var codigo_reg = Decimal.Parse(row["RES_HOTREG_REGIMEN"].ToString());
            var codigo = Decimal.Parse(row["RES_CODIGO"].ToString());
        //    var f_carga = DateTime.Parse("07/10/2014 09:56:50 p.m.");
        //    var f_desde = DateTime.Parse("07/10/2014 09:56:50 p.m.");
        //    var f_inici = DateTime.Parse("07/10/2014 09:56:50 p.m.");
            var f_carga = DateTime.Parse(row["RES_FECHA_CARGA"].ToString());
            var f_desde = DateTime.Parse(row["RES_FECHA_DESDE"].ToString());
            var f_inici = DateTime.Parse(row["RES_FECHA_HASTA"].ToString());

            var reserv = new Reserva(codigo,f_inici,f_desde,f_carga, codigo_hot,codigo_reg,codigo_est );
            return reserv;
        }
        
    }
}
