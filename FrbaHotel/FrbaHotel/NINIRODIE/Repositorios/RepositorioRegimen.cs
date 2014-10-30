using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioRegimen
    {
        private static RepositorioRegimen _instance;

        public static RepositorioRegimen Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioRegimen();
                }
                return _instance;
            }

        }

        public Regimen BuscarRegimen(Decimal cod)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.REGIMEN WHERE REG_CODIGO = '{0}'", cod);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.REGIMEN");

            var regimen = dataRow.ToList<Regimen>(this.DataRowToRegimen);
            return regimen.First();
        }

        public Regimen DataRowToRegimen(DataRow row)
        {
            var codigo = Decimal.Parse(row["REG_CODIGO"].ToString());
            var precio = Decimal.Parse(row["REG_PRECIO"].ToString());
            var des = row["REG_DESCRIPCION"].ToString();
            var hab = bool.Parse(row["REG_HABILITADO"].ToString());

            var reg = new Regimen(codigo, des, precio, hab);
            return reg;
        }


    }
}
