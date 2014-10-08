using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class Resusu
    {
        public Decimal identificador_reserva { get; set; }
        public DateTime entrada { get; set; }
        public DateTime salida { get; set; }
        public Decimal identificador_usuario { get; set; }
        public Decimal identificador_usu_ope { get; set; }

        public Resusu(Decimal id, DateTime ent, DateTime sal, Decimal usu, Decimal op)
        {
            identificador_reserva = id;
            entrada = ent;
            salida = sal;
            identificador_usu_ope = op;
            identificador_usuario = usu;
        }
    }
}
