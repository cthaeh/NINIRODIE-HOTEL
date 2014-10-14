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

        public List<FunRol> BuscarFunRol(Decimal cod_rol)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.FUNCION_ROL WHERE " +
                "FUNROL_ROL = '{0}' AND FUNROL_HABILITADO = '{1}'", cod_rol, 1);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.FUNCION_ROL");

            var roles = dataRow.ToList<FunRol>(this.DataRowToFunRol);
            return roles;
        }

        public void BajarRol(Decimal cod_rol, int hab)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.ROL SET " +
                "ROL_HABILITADO = '{0}' WHERE ROL_CODIGO = '{1}'", hab, cod_rol);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void ModificarRol(String nombre, Decimal cod_rol)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.ROL SET " +
                "ROL_DESCRIPCION = '{0}' WHERE ROL_CODIGO = '{1}'", nombre, cod_rol);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void ActivarRol(Decimal cod_rol, Decimal cod_fun)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.FUNCION_ROL SET " +
                "FUNROL_HABILITADO = '{0}' WHERE FUNROL_ROL = '{1}' AND FUNROL_FUNCION = '{2}'",
                1, cod_rol, cod_fun);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public void DeshabilitarTodos(Decimal cod_rol)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.FUNCION_ROL SET " +
                "FUNROL_HABILITADO = '{0}' WHERE FUNROL_ROL = '{1}'",
                0, cod_rol);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public List<Rol> BuscarRoles()
        {
            String filtro = "GOD";
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.ROL WHERE ROL_DESCRIPCION != '{0}'", filtro);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.ROL");

            var roles = dataRow.ToList<Rol>(this.DataRowToRol);
            return roles;
        }

        public void InsertarRol(String nombre)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.ROL " +
                "(ROL_HABILITADO, ROL_DESCRIPCION) VALUES ('{0}', '{1}')",
                1, nombre);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Rol ExisteRolMod(String nombre)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.ROL WHERE ROL_DESCRIPCION = '{0}'", nombre);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.ROL");

            if (dataRow.Count > 0)
            {
                var roles = dataRow.ToList<Rol>(this.DataRowToRol);
                return roles.First();
            }
            else
            {
                return new Rol();
            }
        }

        public Decimal ExisteRol(String nombre)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.ROL WHERE ROL_DESCRIPCION = '{0}'", nombre);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.ROL");

            if (dataRow.Count > 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public Rol BuscarRol(String nombre)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.ROL WHERE ROL_DESCRIPCION = '{0}'", nombre);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.ROL");

            var roles = dataRow.ToList<Rol>(this.DataRowToRol);
            return roles.First();

        }

        public FunRol DataRowToFunRol(DataRow row)
        {
            var cod_rol = Decimal.Parse(row["FUNROL_ROL"].ToString());
            var cod_fun = Decimal.Parse(row["FUNROL_FUNCION"].ToString());
            var habilitado = bool.Parse(row["FUNROL_HABILITADO"].ToString());

            var funrol = new FunRol(cod_rol, cod_fun, habilitado);
            return funrol;
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
