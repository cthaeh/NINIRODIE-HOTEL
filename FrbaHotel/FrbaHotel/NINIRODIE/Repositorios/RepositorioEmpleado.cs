using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.NINIRODIE.DBUtils;

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
    }
}
