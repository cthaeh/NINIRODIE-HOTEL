using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioConsumibles
    {
        private static RepositorioConsumibles _instance;

        public static RepositorioConsumibles Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioConsumibles();
                }
                return _instance;
            }
        }

        public List<Consumibles> BuscarConsu()
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.CONSUMBILES");

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.CONSUMBILES");

            var consu = dataRow.ToList<Consumibles>(this.DataRowToConsu);

            return consu;
        }

        public Decimal BuscarMonto(Decimal cod_consu)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.CONSUMBILES WHERE CONS_CODIGO = '{0}'", cod_consu);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.CONSUMBILES");

            return Decimal.Parse(dataRow[0]["CONS_PRECIO"].ToString());

        }

        public Consumibles DataRowToConsu(DataRow row)
        {
            var codigo = Decimal.Parse(row["CONS_CODIGO"].ToString());
            var pre = Decimal.Parse(row["CONS_PRECIO"].ToString());
            var desc = row["CONS_DESCRIPCION"].ToString();

            var cons = new Consumibles(codigo, pre, desc);

            return cons;

        }
    }
}
