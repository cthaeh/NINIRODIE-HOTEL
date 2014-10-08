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

        public void InsertarHabitacion(Decimal cod_hot, Decimal nro, Decimal piso,
            String desc, String ubi, Decimal tipo)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.HABITACION " +
                "(HAB_COD_HOTEL, HAB_NUMERO, HAB_PISO, HAB_UBICACION, HAB_COD_TIPOHABITACION, " +
                "HAB_HABILITADA, HAB_DESCRIPCION) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                cod_hot, nro, piso, ubi, tipo, 1, desc);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Habitacion DataRowToHotemp(DataRow row)
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
