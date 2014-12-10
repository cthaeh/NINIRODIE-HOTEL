using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.LA_REVANCHA.Clases
{
    public class Personal
    {
        public Decimal identificador { get; set; }
        public Decimal codigo_usuario { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String tipo_documento { get; set; }
        public Decimal numero_documento { get; set; }
        public String mail { get; set; }
        public Decimal telefono { get; set; }
        public String direccion { get; set; }
        public DateTime nacimiento { get; set; }

        public Personal()
        {
            identificador = -1;
        }
        public Personal(Decimal id, Decimal cod_usu, String nomb, String ap,
            String tipo_doc, Decimal nro_doc, String email, Decimal tel,
            String dir, DateTime fecha_nac) :
            this(nomb, ap, tipo_doc, nro_doc, email, tel,
            dir, fecha_nac)
        {
            identificador = id;
            codigo_usuario = cod_usu;
        }

        public Personal(String nomb, String ap,
    String tipo_doc, Decimal nro_doc, String email, Decimal tel,
    String dir, DateTime fecha_nac)
        {
            nombre = nomb;
            apellido = ap;
            tipo_documento = tipo_doc;
            numero_documento = nro_doc;
            mail = email;
            telefono = tel;
            direccion = dir;
            nacimiento = fecha_nac;
        }
    }
}
