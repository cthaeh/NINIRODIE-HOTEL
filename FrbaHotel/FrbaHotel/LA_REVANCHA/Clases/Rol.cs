using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.LA_REVANCHA.Clases
{
    public class Rol
    {
        public Decimal identificador { get; set; }
        public String descripcion { get; set; }
        public bool habilitado { get; set; }

        public Rol()
        {
            identificador = -1;
        }

        public Rol(Decimal id, String desc, bool hab)
        {
            identificador = id;
            descripcion = desc;
            habilitado = hab;
        }
    }
}
