using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.NINIRODIE.DBUtils;
using System.Data;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioEmpleado
    {
        private static RepositorioEmpleado _instance;

        public static RepositorioEmpleado Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioEmpleado();
                }
                return _instance;
            }
        }

        public void Modificar(String apellido, String direccion, Decimal dni,
            String mail, String nombre, Decimal telefono, Decimal codigo)
        {
            var query = String.Format(@"UPDATE LA_REVANCHA.PERSONAL SET PER_APELLIDO = " +
"'{0}', PER_NOMBRE = '{1}', PER_DIRECCION = '{2}', PER_NUMERO_IDENTIFICACION = '{3}', PER_MAIL = '{4}', PER_TELEFONO = '{5}' WHERE PER_COD_USUARIO = '{6}'"
, apellido, nombre, direccion, dni, mail, telefono, codigo);

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public Personal BuscarEmpleadoXCod(Decimal ident)
        {
            var query = String.Format(@"Select * FROM LA_REVANCHA.PERSONAL WHERE " +
                "PER_CODIGO = '{0}' ", ident);

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.PERSONAL");

            var empleados = dataRow.ToList<Personal>(this.DataRowToPersonal);

            return empleados.First();

        }

        public void GenerarEmpleado(Personal emp, Decimal cod_usu)
        {
            var query = String.Format(@"INSERT INTO LA_REVANCHA.PERSONAL " +
                "(PER_COD_USUARIO, PER_NOMBRE, PER_APELLIDO, PER_NUMERO_IDENTIFICACION, " +
                "PER_TIPO_IDENTIFICACION, PER_MAIL, PER_TELEFONO, PER_DIRECCION, PER_FECHA_NACIMIENTO) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}','{7}','{8}')", cod_usu,
                emp.nombre, emp.apellido, emp.numero_documento, emp.tipo_documento, emp.mail,
                emp.telefono, emp.direccion, DBTypeConverter.ToSQLDateTime(emp.nacimiento));

            SQLUtils.EjecutarConsultaConEfectoDeLado(query);
        }

        public List<Personal> BuscarEmpleadoD(String apellido, String mail, String nombre, Decimal documento)
        {
            var query = String.Format(@"Select * FROM LA_REVANCHA.PERSONAL WHERE 1 = 1 ");

            if (apellido != "")
            {
                query = query + "AND PER_APELLIDO = '" + apellido + "' ";
            }
            if (nombre != "")
            {
                query = query + "AND PER_NOMBRE = '" + nombre + "' ";
            }
            if (documento != 0)
            {
                query = query + "AND PER_NUMERO_IDENTIFICACION = " + documento;
            }
            if (mail != "")
            {
                query = query + "AND PER_MAIL = '" + mail + "' ";
            }

            DataRowCollection dataRow = SQLUtils.EjecutarConsultaSimple(query, "LA_REVANCHA.PERSONAL");

            var empleados = dataRow.ToList<Personal>(this.DataRowToPersonal);
            return empleados;
            
        }

        public Personal DataRowToPersonal(DataRow row)
        {
            var codigo = Decimal.Parse(row["PER_CODIGO"].ToString());
            var usu = Decimal.Parse(row["PER_COD_USUARIO"].ToString());
            var nombre = row["PER_NOMBRE"].ToString();
            var apellido = row["PER_APELLIDO"].ToString();
            var tipo_docu = row["PER_TIPO_IDENTIFICACION"].ToString();
            var nro_doc = Decimal.Parse(row["PER_NUMERO_IDENTIFICACION"].ToString());

            Decimal telef = 0;
            if (!row["PER_TELEFONO"].Equals(DBNull.Value))
                telef = Decimal.Parse(row["PER_TELEFONO"].ToString());

            var meil = row["PER_MAIL"].ToString();
            var f_nac = DateTime.Parse("07/10/2014 09:56:50 p.m.");

            var dir = row["PER_DIRECCION"].ToString();

            var personal = new Personal(codigo, usu, nombre, apellido, tipo_docu, nro_doc,
                meil, telef, dir, f_nac);

            return personal;
        }
    }
}
