using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.LA_REVANCHA.Clases
{
    public class Escoit
    {
        public Decimal identificador { get; set; }
        public Decimal cod_consumible { get; set; }
        public Decimal cod_estadia { get; set; }
        public Decimal cod_habitacion { get; set; }
        public Decimal cod_item { get; set; }
        public Decimal cantidad { get; set; }

        public Escoit(Decimal id, Decimal consu, Decimal est, Decimal hab, Decimal it, Decimal cant)
        {
            identificador = id;
            cod_consumible = consu;
            cod_estadia = est;
            cod_habitacion = hab;
            cod_item = it;
            cantidad = cant;
        }

        public Escoit()
        {
            identificador = 0;
        }
    }
}
