using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioHabitacion
    {
        private static RepositorioHabitacion _instance;

        public static RepositorioHabitacion Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioHabitacion();
                }
                return _instance;
            }
        }

        public void ModificarHabitacion(String piso, String nro, String desc, String ubi, Decimal cod_hab)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HABITACION SET HAB_PISO = '{0}', " +
                "HAB_NUMERO = '{1}', HAB_DESCRIPCION = '{2}', HAB_UBICACION = '{3}' WHERE HAB_CODIGO = '{4}' ",
                Decimal.Parse(piso), Decimal.Parse(nro), desc, ubi , cod_hab);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);

        }

        public void BajarHab(Decimal codigo, int habilitado)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.HABITACION SET HAB_HABILITADA = '{0}' WHERE HAB_CODIGO = '{1}'", habilitado, codigo);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Habitacion BuscarHab(Decimal codigo)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HABITACION WHERE HAB_CODIGO = '{0}'", codigo);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HABITACION");

            var habitacion = dataRow.ToList<Habitacion>(this.DataRowToHab);
            return habitacion.First();
        }

        public Habitacion ExisteHabMod(Decimal cod_hot, Decimal nro)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HABITACION WHERE HAB_COD_HOTEL = '{0}' AND HAB_NUMERO = '{1}'", cod_hot, nro);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HABITACION");

            if (dataRow.Count > 0)
            {
                var habitacion = dataRow.ToList<Habitacion>(this.DataRowToHab);
                return habitacion.First();
            }
            else
            {
                return new Habitacion();
            }
        }

        public Decimal ExisteHab(Decimal cod_hot, Decimal nro)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.HABITACION WHERE HAB_COD_HOTEL = '{0}' AND HAB_NUMERO = '{1}'", cod_hot, nro);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HABITACION");

            if (dataRow.Count > 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public List<Habitacion> BuscarHabitacion(String numero, String piso, Decimal tipo, Decimal hot)
        {
            var query = String.Format(@"Select * FROM LA_REVANCHA.HABITACION WHERE 1 = 1 ");

            if (numero != "")
            {
                query = query + "AND HAB_NUMERO = " + Decimal.Parse(numero) ;
            }
            if (piso != "")
            {
                query = query + "AND HAB_PISO = " + Decimal.Parse(piso);
            }
            if (tipo != 0)
            {
                query = query + "AND HAB_COD_TIPOHABITACION = " + tipo;
            }
            query = query + "AND HAB_COD_HOTEL = " + hot;

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.HABITACION");

            var habitacion = dataRow.ToList<Habitacion>(this.DataRowToHab);
            return habitacion;

        }

        public void InsertarHabitacion(Decimal cod_hot, Decimal nro, Decimal piso,
            String desc, String ubi, Decimal tipo)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.HABITACION " +
                "(HAB_COD_HOTEL, HAB_NUMERO, HAB_PISO, HAB_UBICACION, HAB_COD_TIPOHABITACION, " +
                "HAB_HABILITADA, HAB_DESCRIPCION) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                cod_hot, nro, piso, ubi, tipo, 1, desc);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Habitacion DataRowToHab(DataRow row)
        {
            var codigo = Decimal.Parse(row["HAB_CODIGO"].ToString());
            var numero = Decimal.Parse(row["HAB_NUMERO"].ToString());
            var cod_hotel = Decimal.Parse(row["HAB_COD_HOTEL"].ToString());
            var piso = Decimal.Parse(row["HAB_PISO"].ToString());
            var ubi = row["HAB_UBICACION"].ToString();
            var tipo = Decimal.Parse(row["HAB_COD_TIPOHABITACION"].ToString());
            var hab = bool.Parse(row["HAB_HABILITADA"].ToString());
            var desc = row["HAB_DESCRIPCION"].ToString();

            var habitacion = new Habitacion(codigo, numero, cod_hotel, piso,tipo,ubi,desc,hab);
            return habitacion;
        }
    }
}
