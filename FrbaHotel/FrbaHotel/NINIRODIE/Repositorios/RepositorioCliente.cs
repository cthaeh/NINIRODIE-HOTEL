using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioCliente
    {
        private static RepositorioCliente _instance;

        public static RepositorioCliente Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioCliente();
                }
                return _instance;
            }
        }

        public void InsertarCliente(Cliente cliente)
        {

            var query = String.Format(@"INSERT INTO NINIRODIE.CLIENTE " +
                "(CLI_TIPO_DOC, CLI_NRO_DOC, CLI_NOMBRE, CLI_APELLIDO, " +
                "CLI_TELEFONO, CLI_MAIL, CLI_FECHA_NAC, CLI_SEXO, CLI_CIUDAD, " +
                 "CLI_LOCALIDAD, CLI_CALLE, CLI_ALTURA, CLI_PISO, " +
                 "CLI_DEPARTAMENTO, CLI_CODIGO_POSTAL)" +
                "VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', " +
                 "'{9}','{10}','{11}','{12}','{13}','{14}')", cliente.tipo_documento,
                 cliente.numero_documento, cliente.nombre, cliente.apellido, cliente.telefono,
                 cliente.mail, DBTypeConverter.ToSQLDateTime(cliente.nacimiento), cliente,
                 cliente.loc, cliente.call, cliente.altu, cliente.pis, cliente.puert,
                 cliente.codpos);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);

        }
    }
}
