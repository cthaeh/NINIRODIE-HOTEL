using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    public class Estadistica2
    {
        public Decimal identificador { get; set; }
        public String nombre { get; set; }
        public String mail { get; set; }
        public Decimal telefono { get; set; }
        public String Calle { get; set; }
        public Decimal nro_calle { get; set; }
        public Decimal categoria { get; set; }
        public Decimal recarga { get; set; }
        public String ciudad { get; set; }
        public String pais { get; set; }
        public DateTime creacion { get; set; }
		public bool habilitado { get; set; }
        public Decimal cant_consumibles { get; set; }

        public Estadistica2()
        {
            identificador = -1;
        }

        public Estadistica2(Decimal id, String nom, String email, Decimal tel,
            String calle,Decimal nro_calle, Decimal cat, String ciu, String paiz, DateTime nacimiento, bool hab, Decimal rec, Decimal cant)
        : this(nom, email, tel,calle,nro_calle, cat, ciu, paiz, nacimiento, hab, rec, cant)
        {
            identificador = id;

        }

        public Estadistica2(String nom, String email, Decimal tel,
            String dir, Decimal nro, Decimal cat, String ciu, String paiz, DateTime nacimiento, bool hab, Decimal rec, Decimal cant)
        {
            cant_consumibles = cant;
            habilitado = hab;
            Calle = dir;
            nombre = nom;
            mail = email;
            nro_calle = nro;
            telefono = tel;
            ciudad = ciu;
            pais = paiz;
            creacion = nacimiento;
            categoria = cat;
            recarga = rec;
        }
    }
}
