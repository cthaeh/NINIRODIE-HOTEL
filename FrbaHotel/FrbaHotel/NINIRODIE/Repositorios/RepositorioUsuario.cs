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

        public void BloquearUsuario(Decimal cod)
        {
         var query = String.Format(@"UPDATE LA_REVANCHA.USUARIO SET USU_BLOQUEADO = " +
                  "'{0}' WHERE USU_CODIGO = '{1}'", 1, cod);

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
