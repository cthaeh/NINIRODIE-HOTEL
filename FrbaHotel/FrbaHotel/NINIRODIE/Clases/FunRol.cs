using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    public class FunRol
    {
        public Decimal cod_rol { get; set; }
        public Decimal cod_fun { get; set; }
        public bool habilitado { get; set; }

        public FunRol(Decimal rol, Decimal fun, bool hab)
        {
            cod_rol = rol;
            cod_fun = fun;
            habilitado = hab;
        }
    }
}
