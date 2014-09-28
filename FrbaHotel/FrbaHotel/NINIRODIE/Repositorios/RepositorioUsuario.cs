using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioUsuario
    {
        private static RepositorioUsuario _instance;

        public static RepositorioUsuario Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioUsuario();
                }
                return _instance;
            }
        }

        public Usuario BuscarUsuario(String id)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.USUARIO " +
                "WHERE USU_USERNAME = '{0}'", id);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "NIINRODIE.USUARIO");

            var usuarios = dataRow.ToList<Usuario>(this.DataRowToUsuario);


            if (usuarios.Count == 0)
            {
                return new Usuario();
            }

            return usuarios.First();

        }

        public Decimal BuscarCodUsuario(String nombreusu)
        {
            var query = String.Format(@"SELECT USU_CODIGO FROM LA_REVANCHA.USUARIO " +
                "WHERE USU_USERNAME = '{0}'", nombreusu);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "NIINRODIE.USUARIO");

            var usuarios = dataRow.ToList<Usuario>(this.DataRowToUsuario);
           
            return usuarios.First().codigo;
        }

        public void GenerarUsuario(String clave, String nombre, String tipo)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.USUARIO " +
                "(USU_USERNAME, USU_PASSWORD, USU_TIPO, USU_HABILITADO, USU_BLOQUEADO) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", nombre, clave, tipo, 1, 0);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);

        }

        public void BloquearUsuario(Decimal cod)
        {
         var query = String.Format(@"UPDATE LA_REVANCHA.USUARIO SET USU_BLOQUEADO = " +
                  "'{0}' WHERE USU_CODIGO = '{1}'", 1, cod);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
            
        }

        public void CambiarClave(Decimal codigo, String clave)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.USUARIO SET USU_PASSWORD = " +
                "'{0}' WHERE USU_CODIGO = '{1}'", clave, codigo);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Usuario DataRowToUsuario(DataRow row)
        {
            var codigo = Decimal.Parse(row["USU_CODIGO"].ToString());
            var id = row["USU_USERNAME"].ToString();
            var pass = row["USU_PASSWORD"].ToString();
            var habilitado = bool.Parse(row["USU_HABILITADO"].ToString());
            var tipo = row["USU_TIPO"].ToString();
            var bloqueado = bool.Parse(row["USU_BLOQUEADO"].ToString());


            var usuario = new Usuario(codigo, id, pass, habilitado, tipo, bloqueado);

            return usuario;

        }
    }
}
