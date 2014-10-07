using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using System.Data;
using FrbaHotel.NINIRODIE.DBUtils;

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

        public Cliente BuscarClienteD(String apellido, String nombre, String mail, Decimal documento)
        {
            var query = String.Format(@"Select * FROM LA_REVANCHA.CLIENTE WHERE 1 = 1 ");

            if (apellido != "")
            {
                query = query + "AND CLI_APELLIDO = '" + apellido + "' ";
            }
            if (nombre != "")
            {
                query = query + "AND CLI_NOMBRE = '" + nombre + "' ";
            }
            if (documento != 0)
            {
                query = query + "AND CLI_NUMERO_IDENTIFICACION = " + documento;
            }
            if (mail != "")
            {
                query = query + "AND CLI_MAIL = '" + mail + "' ";
            }

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.CLIENTE");

           if (dataRow.Count == 0)
            {
                return new Cliente();
            }
            else
            {
                var clientes = dataRow.ToList<Cliente>(this.DataRowToCliente);
                return clientes.First();
            }
        }

        public void InsertarCliente(Cliente cliente)
        {

            var query = String.Format(@"INSERT INTO LA_REVANCHA.CLIENTE " +
                "(CLI_TIPO_IDENTIFICACION, CLI_NUMERO_IDENTIFICACION, CLI_NOMBRE, CLI_APELLIDO, " +
                "CLI_TELEFONO, CLI_MAIL, CLI_FECHA_NACIMIENTO, CLI_CALLE, " +
                 "CLI_PISO,CLI_DEPARTAMENTO, CLI_LOCALIDAD, CLI_NACIONALIDAD, " +
                 "CLI_PAIS_ORIGEN, CLI_NRO_CALLE)" +
                "VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', " +
                 "'{9}','{10}','{11}','{12}','{13}')", cliente.tipo_documento,
                 cliente.numero_documento, cliente.nombre, cliente.apellido, cliente.telefono,
                 cliente.mail, DBTypeConverter.ToSQLDateTime(cliente.nacimiento), cliente.calle,
                 cliente.piso, cliente.departamento, cliente.localidad, cliente.nacionalidad,
                 cliente.pais,cliente.nro_calle);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);

        }

        public Cliente DataRowToCliente(DataRow row)
        {
            var codigo = Decimal.Parse(row["CLI_CODIGO"].ToString());
            var usu = Decimal.Parse(row["CLI_COD_USUARIO"].ToString());
            var nombre = row["CLI_NOMBRE"].ToString();
            var apellido = row["CLI_APELLIDO"].ToString();
            var tipo_docu = row["CLI_TIPO_IDENTIFICACION"].ToString();
            var nro_doc = Decimal.Parse(row["CLI_NUMERO_IDENTIFICACION"].ToString());

            Decimal telef = 0;
            if (!row["CLI_TELEFONO"].Equals(DBNull.Value))
                telef = Decimal.Parse(row["CLI_TELEFONO"].ToString());

            var meil = row["CLI_MAIL"].ToString();
            var f_nac = DateTime.Parse(row["CLI_FECHA_NACIMIENTO"].ToString());

            String loc = "";
            if (!row["CLI_LOCALIDAD"].Equals(DBNull.Value))
                loc = row["CLI_LOCALIDAD"].ToString();

            var call = row["CLI_CALLE"].ToString();
            var altu = Decimal.Parse(row["CLI_NRO_CALLE"].ToString());
            var pis = Decimal.Parse(row["CLI_PISO"].ToString());
            var puert = Decimal.Parse(row["CLI_DEPARTAMENTO"].ToString());
            var pais = row["CLI_PAIS_ORIGEN"].ToString();
            var nacion = row["CLI_NACIONALIDAD"].ToString();

            var cliente = new Cliente(codigo, usu, nombre, apellido, tipo_docu, nro_doc,
                meil, telef, call, altu, pis, puert, f_nac, loc, pais, nacion);

            return cliente;
        }
    }
}
