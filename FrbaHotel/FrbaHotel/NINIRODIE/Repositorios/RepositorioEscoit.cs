using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.DBUtils;
using System.Data;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioEscoit
    {
        private static RepositorioEscoit _instance;

        public static RepositorioEscoit Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioEscoit();
                }
                return _instance;
            }
        }

        public void InsertarEscoit(Decimal cod_consumible, Decimal cod_estadia, Decimal cantidad, Decimal cod_habitacion)
        {
            var query = String.Format(@"INSERT INTO GD2C2014.LA_REVANCHA.ESTADIA_CONSUMIBLE_ITEM " +
                                      "(ESCOIT_COD_ESTADIA, ESCOIT_COD_CONSUMIBLE, ESCOIT_COD_HABITACION, ESCOIT_CANTIDAD) VALUES " +
                                      "('{0}', '{1}','{2}','{3}')", cod_estadia,cod_consumible,cod_habitacion,cantidad);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void InsertarEstadia(Decimal cod_estadia)
        {
            Decimal cantidad = 1;

            var query = String.Format(@"INSERT INTO GD2C2014.LA_REVANCHA.ESTADIA_CONSUMIBLE_ITEM " +
                                      "(ESCOIT_COD_ESTADIA, ESCOIT_CANTIDAD) VALUES " +
                                      "('{0}', '{1}')", cod_estadia, cantidad);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void ActualizarEscoit()
        {
        }

        public Decimal BuscarEscoit(Decimal estadia)
        {
            var query = String.Format(@"SELECT * FROM GD2C2014.LA_REVANCHA.ESTADIA_CONSUMIBLE_ITEM WHERE ESCOIT_COD_ESTADIA = '{0}'", estadia);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.ESTADIA");
            if (dataRow.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<Escoit> BuscarEscoits(Decimal estadia)
        {
            var query = String.Format(@"SELECT * FROM GD2C2014.LA_REVANCHA.ESTADIA_CONSUMIBLE_ITEM WHERE ESCOIT_COD_ESTADIA = '{0}' AND ESCOIT_COD_CONSUMIBLE != 0 ", estadia);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.ESTADIA");

            var items = dataRow.ToList<Escoit>(this.DataRowToEscoit);

            return items;
            
        }

        public Escoit DataRowToEscoit(DataRow row)
        {
            var codigo = Decimal.Parse(row["ESCOIT_CODIGO"].ToString());
            var cod_consu = Decimal.Parse(row["ESCOIT_COD_CONSUMIBLE"].ToString());
            var cant = Decimal.Parse(row["ESCOIT_CANTIDAD"].ToString());
            var cod_estadia = Decimal.Parse(row["ESCOIT_COD_ESTADIA"].ToString());
            var cod_hab = Decimal.Parse(row["ESCOIT_COD_HABITACION"].ToString());

            var item = new Escoit(codigo, cod_consu, cod_estadia, cod_hab, 0, cant);
            return item;
        }
    }
}
