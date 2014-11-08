using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    public class Reserva
    {
        public Decimal identificador { get; set; }
        public Decimal identificador_hotel { get; set; }
        public Decimal identificador_regimen { get; set; }
        public Decimal identificador_estado { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }

        public Reserva(Decimal id, Decimal id_hot,
            Decimal id_reg, Decimal id_est)
        {
            identificador = id;
            identificador_estado = id_est;
            identificador_hotel = id_hot;
            identificador_regimen = id_reg;
        }

        public Reserva(Decimal id, Decimal id_hot,
            Decimal id_reg, Decimal id_est, DateTime desde, DateTime hasta)
            : this(id, id_hot, id_reg, id_est)
        {
            fechaDesde = desde;
            fechaHasta = hasta;
        }

        public Reserva(Decimal id)
        {
            identificador = id;
        }
		
		public Reserva()
		{
			identificador = 0;
            identificador_estado = 0;
            identificador_hotel = 0;
            identificador_regimen = 0;
		}
    }
}
