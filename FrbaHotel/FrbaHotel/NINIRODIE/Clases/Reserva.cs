using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class Reserva
    {
        public Decimal identificador { get; set; }
        public Decimal identificador_hotel { get; set; }
        public Decimal identificador_regimen { get; set; }
        public Decimal identificador_estado { get; set; }

        public Reserva(Decimal id, Decimal id_hot,
            Decimal id_reg, Decimal id_est)
        {
            identificador = id;
            identificador_estado = id_est;
            identificador_hotel = id_hot;
            identificador_regimen = id_reg;
        }
    }
}
