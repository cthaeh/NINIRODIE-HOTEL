using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class Hotel
    {
        public Decimal identificador { get; set; }
        public String nombre { get; set; }
        public String mail { get; set; }
        public Decimal telefono { get; set; }
        public Decimal nro_calle { get; set; }
        public String calle { get; set; }
        public Decimal categoria { get; set; }
        public String ciudad { get; set; }
        public String pais { get; set; }
        public DateTime creacion { get; set; }
		public bool habilitado { get; set; }

        public Hotel()
        {
            identificador = -1;
        }

        public Hotel(Decimal id, String nom, String email, Decimal tel,
            String cal,Decimal nro_cal, Decimal cat, String ciu, String paiz, DateTime nacimiento, bool hab)
        {
            identificador = id;
			habilitado = hab;
            calle = cal;
            nro_calle = nro_cal;
            nombre = nom;
            mail = email;
            telefono = tel;
            ciudad = ciu;
            pais = paiz;
            creacion = nacimiento;
            categoria = cat;
        }
    }
}
