using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.LA_REVANCHA.Clases
{
    public class Hotemp
    {
        public Decimal identificador_hotel { get; set; }
        public Decimal identificador_usuario { get; set; }
        public bool habilitado { get; set; }

        public Hotemp(Decimal idhot, Decimal idusu, bool hab)
        {
            identificador_hotel = idhot;
            identificador_usuario = idusu;
            habilitado = hab;
        }
    }
}
