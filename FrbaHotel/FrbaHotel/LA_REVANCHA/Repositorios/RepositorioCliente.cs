using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.LA_REVANCHA.Clases;
using System.Data;
using FrbaHotel.LA_REVANCHA.DBUtils;

namespace FrbaHotel.LA_REVANCHA.Repositorios
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

        //--------------------------------------------------------
        public List<Cliente> Estadistica5(String inicio, String fin)
        {
            var query2 = String.Format(@"SELECT DISTINCT TOP 5 CLIENTE.*,(((ESTADIA.EST_PRECIO*TIPO_HABITACION.TIPHAB_CANT_PERSONAS*HOTEL.HOT_ESTRELLAS)/10) + FACTURA.FAC_TOTAL/5) AS PUNTOS_TOTALES
FROM LA_REVANCHA.REGIMEN,LA_REVANCHA.CLIENTE
JOIN LA_REVANCHA.USUARIO ON CLIENTE.CLI_COD_USUARIO = USUARIO.USU_CODIGO
JOIN LA_REVANCHA.RESERVA_USUARIO ON USUARIO.USU_CODIGO = RESERVA_USUARIO.RESUSU_CODUSU_HUESPED
JOIN LA_REVANCHA.RESERVA ON RESERVA_USUARIO.RESUSU_COD_RESERVA = RESERVA.RES_CODIGO
JOIN LA_REVANCHA.ESTADIA ON RESERVA.RES_CODIGO = EST_COD_RESERVA 
JOIN LA_REVANCHA.FACTURA ON EST_COD_RESERVA = FACTURA.FAC_COD_ESTADIA
JOIN LA_REVANCHA.FACTURA_ITEM ON FACTURA.FAC_CODIGO = FACTURA_ITEM.FACITEM_COD_FACTURA
JOIN LA_REVANCHA.HABITACION_RESERVA ON RESERVA.RES_CODIGO = HABITACION_RESERVA.HABRES_COD_RESERVA
JOIN LA_REVANCHA.HABITACION ON HABITACION_RESERVA.HABRES_COD_HABITACION = HABITACION.HAB_CODIGO
JOIN LA_REVANCHA.TIPO_HABITACION ON TIPO_HABITACION.TIPHAB_CODIGO = HABITACION.HAB_COD_TIPOHABITACION
JOIN LA_REVANCHA.HOTEL ON HABITACION.HAB_COD_HOTEL = HOTEL.HOT_CODIGO
WHERE REGIMEN.REG_CODIGO <> 120 AND REGIMEN.REG_CODIGO <> 130 AND FAC_FECHA >= '{0}' AND FAC_FECHA	<= '{1}'
GROUP BY CLI_CODIGO,CLI_COD_USUARIO,CLI_NOMBRE,CLI_APELLIDO,CLI_NUMERO_IDENTIFICACION,CLI_TIPO_IDENTIFICACION, CLI_MAIL,CLI_TELEFONO,CLI_CALLE,CLI_NRO_CALLE, 
         CLI_PISO,CLI_DEPARTAMENTO,CLI_LOCALIDAD,CLI_PAIS_ORIGEN,CLI_NACIONALIDAD,CLI_FECHA_NACIMIENTO, ESTADIA.EST_PRECIO, TIPO_HABITACION.TIPHAB_CANT_PERSONAS, HOTEL.HOT_ESTRELLAS, FACTURA.FAC_TOTAL
ORDER BY PUNTOS_TOTALES DESC", inicio, fin);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query2, "LA_REVANCHA.CLIENTE");

            var clientes = dataRow.ToList<Cliente>(this.DataRowToCliente);
            return clientes;
        }
        //-----------------------------------

        public List<Cliente> BuscarClienteD(String apellido, String nombre, String mail, Decimal documento)
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

                var clientes = dataRow.ToList<Cliente>(this.DataRowToCliente);
                return clientes;
            
        }

        public Cliente ExisteCliMod(Decimal dni)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.CLIENTE WHERE CLI_NUMERO_IDENTIFICACION = '{0}'", dni);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.CLIENTE");

            if (dataRow.Count > 0)
            {
                var clientes = dataRow.ToList<Cliente>(this.DataRowToCliente);
                return clientes.First();
            }
            else
            {
                return new Cliente();
            }
        }

        public Decimal ExisteCli(Decimal dni)
        {
            var query = String.Format(@"SELECT * FROM LA_REVANCHA.CLIENTE WHERE CLI_NUMERO_IDENTIFICACION = '{0}'", dni);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.CLIENTE");

            if (dataRow.Count > 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public void ModificarCliente(Cliente cliente, Decimal codigo)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.CLIENTE SET " +
                "CLI_TIPO_IDENTIFICACION = '{0}', CLI_NUMERO_IDENTIFICACION = '{1}', CLI_NOMBRE = '{2}', CLI_APELLIDO = '{3}', " +
                "CLI_TELEFONO = '{4}', CLI_MAIL = '{5}', CLI_FECHA_NACIMIENTO = '{6}', CLI_CALLE = '{7}', " +
                 "CLI_PISO = '{8}',CLI_DEPARTAMENTO = '{9}', CLI_LOCALIDAD = '{10}', CLI_NACIONALIDAD = '{11}', " +
                 "CLI_PAIS_ORIGEN = '{12}', CLI_NRO_CALLE = '{13}' WHERE CLI_CODIGO = '{14}'", cliente.tipo_documento,
                 cliente.numero_documento, cliente.nombre, cliente.apellido, cliente.telefono,
                 cliente.mail, DBTypeConverter.ToSQLDateTime(cliente.nacimiento), cliente.calle,
                 cliente.piso, cliente.departamento, cliente.localidad, cliente.nacionalidad,
                 cliente.pais, cliente.nro_calle, codigo);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
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
           // var f_nac = DateTime.Parse("07/10/2014 09:56:50 p.m.");
            var f_nac = DateTime.Parse(row["CLI_FECHA_NACIMIENTO"].ToString());

            String loc = "";
            if (!row["CLI_LOCALIDAD"].Equals(DBNull.Value))
                loc = row["CLI_LOCALIDAD"].ToString();

            var call = row["CLI_CALLE"].ToString();
            var altu = Decimal.Parse(row["CLI_NRO_CALLE"].ToString());
            var pis = Decimal.Parse(row["CLI_PISO"].ToString());
            var puert = row["CLI_DEPARTAMENTO"].ToString();
            var pais = row["CLI_PAIS_ORIGEN"].ToString();
            var nacion = row["CLI_NACIONALIDAD"].ToString();

            var cliente = new Cliente(codigo, usu, nombre, apellido, tipo_docu, nro_doc,
                meil, telef, call, altu, pis, puert, f_nac, loc, pais, nacion);

            return cliente;
        }

        public List<Cliente> BuscarCliente(Decimal idNumero, String tipoId, String mail)
        {
            var query = String.Format(@"SELECT * FROM GD2C2014.LA_REVANCHA.CLIENTE " +
                                      "WHERE " + this.busquedaConId(idNumero, tipoId) +
                                      this.busquedaConMail(idNumero, tipoId, mail), idNumero, tipoId, mail);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.CLIENTE");

            return dataRow.ToList<Cliente>(this.DataRowToCliente);
        }

        private string busquedaConMail(Decimal numero, String tipo, String mail)
        {
            if (mail != "" & (numero != 0 & tipo != ""))
                return "AND CLI_MAIL LIKE '%{2}%'";
            if (mail != "" & !(numero != 0 & tipo != ""))
                return "CLI_MAIL LIKE '%{2}%'";
            else
                return "";
        }

        private string busquedaConId(Decimal numero, String tipo)
        {
            if (numero != 0 & tipo != "")
                return "CLI_NUMERO_IDENTIFICACION = '{0}' AND CLI_TIPO_IDENTIFICACION = '{1}' ";
            else
                return "";
        }



        internal Cliente UltimoIdConUsuarioYPasswordCreado()
        {
            var query = String.Format(@"SELECT TOP 1 * FROM GD2C2014.LA_REVANCHA.CLIENTE " +
                                        "ORDER BY CLI_CODIGO DESC");

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "GD2C2014.LA_REVANCHA.CLIENTE");

            return dataRow.ToList<Cliente>(this.DataRowToCliente).First();
        }
    }
}
