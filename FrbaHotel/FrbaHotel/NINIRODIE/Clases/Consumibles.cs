using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class Consumibles
    {
        public Decimal codigo { get; set; }
        public Decimal precio { get; set; }
        public String descripcion { get; set; }

        public Consumibles(Decimal cod, Decimal pr, String des)
        {
            codigo = cod;
            precio = pr;
            descripcion = des;
        }
    }
}
