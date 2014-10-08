using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.DBUtils;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioRol
    {
        private static RepositorioRol _instance;

        public static RepositorioRol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioRol();
                }
                return _instance;
            }
        }

        public void ActivarRol(Decimal cod_rol, Decimal cod_fun)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.FUNCION_ROL SET " +
                "FUNROL_HABILITADO = '{0}' WHERE FUNROL_ROL = '{1}' AND FUNROL_FUNCION = '{2}'",
                1, cod_rol, cod_fun);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void InsertarRol(String nombre)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.ROL " +
                "(ROL_HABILITADO, ROL_DESCRIPCION) VALUES ('{0}', '{1}')",
                1, nombre);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Rol BuscarRol(String nombre)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.ROL WHERE ROL_DESCRIPCION = '{0}'", nombre);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.ROL");

            var roles = dataRow.ToList<Rol>(this.DataRowToRol);
            return roles.First();

        }

        public Rol DataRowToRol(DataRow row)
        {
            var codigo = Decimal.Parse(row["ROL_CODIGO"].ToString());
            var nombre = row["ROL_DESCRIPCION"].ToString();
            var habilitado = bool.Parse(row["ROL_HABILITADO"].ToString());

            var rol = new Rol(codigo, nombre, habilitado);
            return rol;
        }
    }
}
