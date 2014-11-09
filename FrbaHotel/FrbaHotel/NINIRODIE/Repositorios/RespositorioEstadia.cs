using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RespositorioEstadia
    {
        private static RespositorioEstadia _instance;

        public static RespositorioEstadia Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RespositorioEstadia();
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
    }
}
