using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class Cancelacion
    {
        public Decimal codigo { get; set; }
        public String motivo { get; set; }
        public Decimal codigoReserva { get; set; }
        public Decimal codigoUsuario { get; set; }
        public DateTime fechaCancelacion { get; set; }

        public Cancelacion(Decimal cod)
        {
            codigo = cod;
        }

        public Cancelacion(String motive, Decimal reservacodigo, Decimal userCodigo)
        {
            motivo = motive;
            codigoReserva = reservacodigo;
            codigoUsuario = userCodigo;
        }

        public Cancelacion(Decimal codig, String motive, Decimal reservacodigo, Decimal userCodigo, DateTime fechaCanc)
            : this(motive, reservacodigo, userCodigo)
        {
            codigo = codig;
            fechaCancelacion = fechaCanc;
        }
    }
}
