using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.DBUtils;

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
    }
}
