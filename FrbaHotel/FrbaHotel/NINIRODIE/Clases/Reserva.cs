using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class Reserva
    {
        public Decimal identificador { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fin { get; set; }
        public DateTime carga { get; set; }
        public Decimal identificador_hotel { get; set; }
        public Decimal identificador_regimen { get; set; }
        public Decimal identificador_estado { get; set; }

        public Reserva(Decimal id, DateTime ini, DateTime f, DateTime car, Decimal id_hot,
            Decimal id_reg, Decimal id_est)
        {
            identificador = id;
            inicio = ini;
            fin = f;
            carga = car;
            identificador_estado = id_est;
            identificador_hotel = id_hot;
            identificador_regimen = id_reg;
        }
    }
}
