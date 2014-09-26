using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class Personal
    {
        public Decimal identificador { get; set; }
        public Decimal codigo_usuario { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String tipo_documento { get; set; }
        public Decimal numero_documento { get; set; }
        public String mail { get; set; }
        public Decimal telefono { get; set; }
        public String calle { get; set; }
        public Decimal nro_calle { get; set; }
        public Decimal piso { get; set; }
        public String departamento { get; set; }
        public String localidad { get; set; }
        public DateTime nacimiento { get; set; }

        public Personal()
        {
            identificador = -1;
        }

        public Personal(Decimal id, Decimal cod_usu, String nomb, String ap,
            String tipo_doc, Decimal nro_doc, String email, Decimal tel,
            String cal, DateTime fecha_nac, Decimal pis, String depar, Decimal nro_cal)
        {
            identificador = id;
            codigo_usuario = cod_usu;
            nombre = nomb;
            apellido = ap;
            tipo_documento = tipo_doc;
            numero_documento = nro_doc;
            nro_calle = nro_cal;
            mail = email;
            piso = pis;
            departamento = depar;

            telefono = tel;
            calle = cal;
            nacimiento = fecha_nac;
        }
    }
}
