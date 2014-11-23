using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    public class Item
    {
        public Decimal codigo_consumible { get; set; }
        public Decimal precio { get; set; }
        public String descripcion { get; set; }
        public Decimal cantidad { get; set; }

        public Item(Decimal cod, Decimal pre, String des, Decimal cant)
        {
            codigo_consumible = cod;
            precio = pre;
            descripcion = des;
            cantidad = cant;
        }
    }
}
