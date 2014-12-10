using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.LA_REVANCHA.Clases
{
    class Resusu
    {
        public Decimal identificador_reserva { get; set; }
        public Decimal identificador_usuario { get; set; }
        public Decimal identificador_usu_ope { get; set; }

        public Resusu(Decimal id, Decimal usu, Decimal op)
        {
            identificador_reserva = id;
            identificador_usu_ope = op;
            identificador_usuario = usu;
        }
    }
}
