using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class Cliente
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
        public Decimal departamento { get; set; }
        public String localidad { get; set; }
        public String pais { get; set; }
        public String nacionalidad { get; set; }
        public DateTime nacimiento { get; set; }

        public Cliente()
        {
            identificador = -1;
        }

        public Cliente(Decimal id, Decimal cod_usu, String nomb, String ap,
            String tipo_doc, Decimal nro_doc, String email, Decimal tel,
            String cal, Decimal nro_cal, Decimal pis, Decimal dep, DateTime fecha_nac, String loc, String origen, String nacion) : 
            this(nomb, ap,
            tipo_doc, nro_doc, email, tel,
            cal, nro_cal, pis, dep, fecha_nac, loc, origen, nacion)
        {
            identificador = id;
            codigo_usuario = cod_usu;
         }

        public Cliente(String nomb, String ap,
    String tipo_doc, Decimal nro_doc, String email, Decimal tel,
    String cal, Decimal nro_cal, Decimal pis, Decimal dep, DateTime fecha_nac, String loc, String origen, String nacion)
        {
            nombre = nomb;
            apellido = ap;
            tipo_documento = tipo_doc;
            numero_documento = nro_doc;
            mail = email;
            telefono = tel;
            calle = cal;
            pis = piso;
            departamento = dep;
            nro_calle = nro_cal;
            nacimiento = fecha_nac;
            localidad = loc;
            pais = origen;
            nacionalidad = nacion;
        }
    }
}
