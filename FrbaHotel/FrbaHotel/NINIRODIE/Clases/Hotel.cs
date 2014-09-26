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
        public String direccion { get; set; }
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
            String dir, Decimal cat, String ciu, String paiz, DateTime nacimiento, bool hab)
        {
            identificador = id;
			habilitado = hab;
            direccion = dir;
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
