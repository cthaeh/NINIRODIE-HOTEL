using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioFuncionalidad
    {
        private static RepositorioFuncionalidad _instance;

        public static RepositorioFuncionalidad Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RepositorioFuncionalidad();
                return _instance;
            }
        }

        public List<Funcionalidad> All()
        {
            var query = String.Format(@"SELECT * FROM NINIRODIE.FUNCION");

            DataRowCollection dataRows = SQLUtils.EjecutarConsultaSimple(query, "NINIRODIE.FUNCION");
                
            return ConvertirAFuncionalidades(dataRows);

        }

        public List<Funcionalidad> FuncionalidadesDisponiblesPara(Rol rol)
        {
            var query = String.Format(@"SELECT * FROM NINIRODIE.FUNCION WHERE " +
                "FUN_CODIGO NOT IN (SELECT FUNROL_FUNCION FROM NINIRODIE.FUNCION_ROL " +
                "WHERE FUNROL_ROL = '{0}' GROUP BY FUNROL_FUNCION)", rol.identificador);

            DataRowCollection dataRows = SQLUtils.EjecutarConsultaSimple(query,"NINIRODIE.FUNCION");

            return ConvertirAFuncionalidades(dataRows);
        }

        public List<Funcionalidad> FuncionalidadesDeRol(Rol rol)
        {
            var query = String.Format(@"SELECT FUN_CODIGO, FUN_DESCRIPCION FROM NINIRODIE.FUNCION, " +
                "NINIRODIE.FUNCION_ROL WHERE FUNROL_ROL = '{0}' AND FUNROL_FUNCION = FUN_CODIGO", rol.identificador);

            DataRowCollection dataRows = SQLUtils.EjecutarConsultaSimple(query, "NINIRODIE.FUNCION");

            return ConvertirAFuncionalidades(dataRows);
        }

        public virtual void ModificarFuncionalidades(Rol rol, List<Funcionalidad> funcionalidadesAEliminar)
        {
            this.AgregarFuncionalidades(rol);
            this.RemoverFuncionalidades(rol, funcionalidadesAEliminar);
        }

        public virtual void AgregarFuncionalidades(Rol rol)
        {
            foreach(Funcionalidad funcion in rol.Funcionalidades)
            {
                var query = String.Format(@"IF NOT EXISTS (SELECT FUNROL_ROL, FUNROL_FUNCION " +
                    "FROM NINIRODIE.FUNCION_ROL WHERE FUNROL_ROL = '{0}' AND " +
                    "FUNROL_FUNCION = '{1}') INSERT INTO NINIRODIE.FUNCION_ROL (FUNROL_ROL, FUNROL_FUNCION) " +
                    "VALUES ('{0}', '{1}')", rol.identificador, funcion.ToString("D"));

                SQLUtils.EjecutarConsultaConEfectoDeLado(query);
            }
        }

        public virtual void RemoverFuncionalidades(Rol rol, List<Funcionalidad> funcionesAEliminar)
        {
            foreach (Funcionalidad funcion in funcionesAEliminar)
            {
                var query = String.Format(@"DELETE FROM NINIRODIE.FUNCION_ROL " +
                    "WHERE FUNROL_ROL = '{0}' AND FUNROL_FUNCION = '{1}'", rol.identificador, funcion.ToString("D"));

                SQLUtils.EjecutarConsultaConEfectoDeLado(query);
            }
        }

        public List<Funcionalidad> FuncionalidadesDe(string rol)
        {
            var query = String.Format(@"SELECT FUN_CODIGO, FUN_DESCRIPCION FROM NINIRODIE.FUNCION " +
                "RIGHT JOIN NINIRODIE.FUNCION_ROL ON FUN_CODIGO = FUNROL_FUNCION " +
                "LEFT JOIN NINIRODIE.ROL ON FUNROL_ROL = ROL_CODIGO WHERE ROL_DESCRIPCION = '{0}'", rol);

            var dataRows = SQLUtils.EjecutarConsultaSimple(query, "NINIRODIE.FUNCION");
            
            var funcionalidades = ConvertirAFuncionalidades(dataRows);
            
            return funcionalidades;
        }

        #region Private Methods

            private List<Funcionalidad> ConvertirAFuncionalidades(DataRowCollection dataRows)
            {
                return dataRows.ToList<Funcionalidad>(this.DataRowToFuncionalidad);
            }

            private Funcionalidad DataRowToFuncionalidad(DataRow row)
            {
                return (Funcionalidad)(int.Parse(row["FUN_CODIGO"].ToString()));
            }
        
        #endregion Private Methods
    }
        }
    

