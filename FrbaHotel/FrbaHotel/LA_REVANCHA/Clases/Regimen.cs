using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.LA_REVANCHA.Clases
{
    public class Regimen
    {
        public Decimal identificador { get; set; }
        public String descripcion { get; set; }
        public Decimal precio { get; set; }
        public bool habilitado { get; set; }

        public Regimen(Decimal id, String des, Decimal p, bool hab)
        {
            identificador = id;
            descripcion = des;
            precio = p;
            habilitado = hab;
        }

        public Regimen() 
        {
            identificador = 0;
        }
    }
}
