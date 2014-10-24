using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class HabRes
    {
        public Decimal identificador_reserva { get; set; }
        public Decimal identificador_habitacion { get; set; }

        public HabRes(Decimal res, Decimal hab)
        {
            identificador_reserva = res;
            identificador_habitacion = hab;
        }
    }

}
