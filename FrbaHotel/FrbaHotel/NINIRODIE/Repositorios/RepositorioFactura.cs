using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.DBUtils;
using System.Data;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioFactura
    {
        private static RepositorioFactura _instance;

        public static RepositorioFactura Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioFactura();
                }
                return _instance;
            }
        }

        public Decimal BuscarMontoFacxRes(Decimal reserva)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.FACTURA WHERE FAC_COD_RESERVA = '{0}'", reserva);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA");

            if (dataRow.Count == 0)
            {
                return 1;
            }
            else
            {
                return Decimal.Parse(dataRow[0]["FAC_TOTAL"].ToString());
            }
        }

        public Decimal BuscarFacturaXRes(Decimal reserva)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.FACTURA WHERE FAC_COD_RESERVA = '{0}'", reserva);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.RESERVA");

            if (dataRow.Count == 0)
            {
                return 1;
            }
            else
            {
                return Decimal.Parse(dataRow[0]["FAC_CODIGO"].ToString());
            }
        }

        public void InsertarItemAFactura(Decimal factura, Decimal consumible, Decimal cantidad, Decimal precio)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.FACTURA_ITEM " +
"(FACITEM_COD_FACTURA, FACITEM_COD_CONSUMIBLE, FACITEM_CANTIDAD, FACITEM_MONTO)" +
"VALUES ({0}, {1}, {2}, {3})", factura, consumible, cantidad, Math.Truncate(precio));

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }
        
        public void IniciarFactura(Decimal reserva)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.FACTURA " +
    "(FAC_CODIGO, FAC_DIAS_ALOJADOS, FAC_DIAS_NO_ALOJADOS, FAC_FECHA, FAC_TOTAL, FAC_COD_FORMA_PAGO, " +
    "FAC_COD_RESERVA) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}')",
    reserva, 0, 0, "2013-01-09 00:00:00.000", 0, 2000, reserva);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }
    }
}
