using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

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
                    _instance = new RepositorioRol();
                return _instance;
            }
        }

        public virtual List<Rol> All()
        {
            var query = String.Format(@"SELECT * FROM NINIRODIE.ROL");

            DataRowCollection dataRows = SQLUtils.EjecutarConsultaSimple(query, "NINIRODIE.ROL");

            return dataRows.Cast<DataRow>().Select(row => this.NuevoRol(row)).ToList();
        }

        public virtual Rol BuscarRol(Rol RolBuscado)
        {
            var query = String.Format(@"SELECT * FROM NINIRODIE.ROL WHERE ROL_CODIGO = '{0}'", RolBuscado.identificador);

            DataRowCollection dataRows = SQLUtils.EjecutarConsultaSimple(query, "NINIRODIE.ROL");

            if (dataRows.Count == 0) return null;

            return this.NuevoRol(dataRows[0]);
        }

        public virtual bool EstaElRol(Rol RolId)
        {
            var query = String.Format(@"SELECT * FROM NINIRODIE.ROL WHERE ROL_CODIGO = '{0}'", RolId.identificador);

            DataRowCollection dataRows = SQLUtils.EjecutarConsultaSimple(query, "NINIRODIE.ROL");

            return dataRows.Count != 0;
        }

        public virtual void AgregarRol(Rol NuevoRol)
        {
            var query = String.Format(@"INSERT INTO NINIRODIE.ROL (ROL_DESCRIPCION, ROL_HABILITADO) " +
                "VALUES ('{0}', '{1}')", NuevoRol.NombreRol, NuevoRol.Habilitado ? 1 : 0);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public virtual void ModificarRol(Rol RolModificado)
        {
            var query = String.Format(@"UPDATE NINIRODIE.ROL SET ROL_HABILITADO = '{0}', " +
                "ROL_DESCRIPCION = '{1}' WHERE ROL_CODIGO = '{2}'",
                RolModificado.Habilitado, RolModificado.NombreRol, RolModificado.identificador);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        private Rol NuevoRol(DataRow row)
        {
            String nombre = row["ROL_DESCRIPCION"].ToString();
            int id = int.Parse(row["ROL_CODIGO"].ToString());
            Boolean habilitado =
                Boolean.Parse(row["ROL_HABILITADO"].ToString())
                || nombre.Equals("ADMINISTRADOR")
                || nombre.Equals("USUARIO")
                || nombre.Equals("EMPRESA");
            return new Rol(id, nombre, habilitado);
        }

        public int NuevoId()
        {
            var query = String.Format(@"SELECT TOP 1 ROL_CODIGO FROM NINIRODIE.ROL ORDER BY ROL_CODIGO DESC");

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "NINIRODIE.ROL");

            return int.Parse(dataRow[0]["ROL_CODIGO"].ToString());
        }

        public void CambiarHabilitacionRol(Rol Rol)
        {
            var query = String.Format(@"UPDATE NINIRODIE.ROL SET ROL_HABILITADO = '{0}' " +
                "WHERE ROL_CODIGO = '{1}'", Rol.Habilitado, Rol.identificador);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }
    }
}
