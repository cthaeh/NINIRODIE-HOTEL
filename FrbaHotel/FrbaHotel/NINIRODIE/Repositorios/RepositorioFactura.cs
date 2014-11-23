using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.DBUtils;
using System.Data;
using FrbaHotel.NINIRODIE.Clases;

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

        public void InsertarFormaPago(String nombre, String apellido, Decimal nro_tarjeta, String forma)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.FORMA_PAGO " +
"(PAGO_DESCRIPCION, PAGO_NOMBRE, PAGO_APELLIDO, PAGO_NRO_TARJETA)" +
"VALUES ('{0}', '{1}', '{2}', '{3}')", forma, nombre, apellido, nro_tarjeta);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void GenerarFactura(Decimal monto, Decimal est, Decimal comprador)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.FACTURA " +
"(FAC_CODIGO, FAC_FECHA, FAC_TOTAL, FAC_COD_FORMA_PAGO, " +
"FAC_COD_ESTADIA, FAC_CONSUMIDOR) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
est, "2013-01-09 00:00:00.000", monto, 2000, est, comprador);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Decimal ExisteHab(Decimal factura, Decimal hab)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.FACTURA_ITEM WHERE FACITEM_COD_FACTURA = '{0}' AND FACITEM_HABITACION = '{1}'", factura, hab);
            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.FACTURA_ITEM");

            if (dataRow.Count == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public void CompletarFactura(Decimal codigo, Decimal cod_pago, Decimal monto)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.FACTURA SET FAC_COD_FORMA_PAGO = '{0}', FAC_TOTAL = '{1}', FAC_FECHA = '{2}' WHERE FAC_CODIGO = '{3}'",
                cod_pago, Math.Truncate(monto), DBTypeConverter.ToSQLDateTime(DateTime.Now), codigo);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Decimal BuscarPago(String nombre, String apellido, Decimal nro_tarjeta, String forma)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.FORMA_PAGO " +
                "WHERE PAGO_DESCRIPCION = '{0}' AND PAGO_NOMBRE = '{1}' AND PAGO_APELLIDO = '{2}' AND PAGO_NRO_TARJETA = '{3}'",
                forma, nombre, apellido, nro_tarjeta);

           DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.FORMA_PAGO");

           return Decimal.Parse(dataRow[0]["PAGO_CODIGO"].ToString());
        }

        public Decimal BuscarMontoFacxRes(Decimal reserva)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.FACTURA WHERE FAC_COD_ESTADIA = '{0}'", reserva);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.FACTURA");

            if (dataRow.Count == 0)
            {
                return 1;
            }
            else
            {
                return Decimal.Parse(dataRow[0]["FAC_TOTAL"].ToString());
            }
        }

        public List<Item> BuscarItemsXFac(Decimal factura)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.FACTURA_ITEM WHERE FACITEM_COD_FACTURA = '{0}'", factura);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.FACTURA_ITEM");

            var items = dataRow.ToList<Item>(this.DataRowToItem);

            return items;
        }

        public Decimal BuscarFacturaXRes(Decimal est)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.FACTURA WHERE FAC_COD_ESTADIA = '{0}'", est);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.FACTURA");

            if (dataRow.Count == 0)
            {
                return 1;
            }
            else
            {
                return Decimal.Parse(dataRow[0]["FAC_CODIGO"].ToString());
            }
        }

        public void InsertarItemAFactura(Decimal factura, Decimal consumible, Decimal cantidad, Decimal precio, Decimal hab)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.FACTURA_ITEM " +
"(FACITEM_COD_FACTURA, FACITEM_COD_CONSUMIBLE, FACITEM_CANTIDAD, FACITEM_MONTO, FACITEM_HABITACION)" +
"VALUES ({0}, {1}, {2}, {3}, '{4}')", factura, consumible, cantidad, Math.Truncate(precio),hab);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }
        
        public void IniciarFactura(Decimal est, Decimal consu)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.FACTURA " +
    "(FAC_CODIGO, FAC_FECHA, FAC_TOTAL, FAC_COD_FORMA_PAGO, " +
    "FAC_COD_ESTADIA, FAC_CONSUMIDOR) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
    est, "2013-01-09 00:00:00.000", 0, 2000, est, consu);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Item DataRowToItem(DataRow row)
        {
            var codigo = Decimal.Parse(row["FACITEM_COD_CONSUMIBLE"].ToString());
            var precio = Decimal.Parse(row["FACITEM_MONTO"].ToString());
            var cant = Decimal.Parse(row["FACITEM_CANTIDAD"].ToString());
            var indent = Decimal.Parse(row["FACITEM_CODIGO"].ToString());
            var desc = "harcodeo";

            var item = new Item(codigo, precio, desc, cant, indent);
            return item;
        }
    }
}
