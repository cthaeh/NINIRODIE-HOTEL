using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.LA_REVANCHA.Clases
{
    public class Habitacion
    {
        public Decimal identificador { get; set; }
        public Decimal numero { get; set; }
        public Decimal codigo_hotel { get; set; }
        public Decimal piso { get; set; }
        public String ubicacion { get; set; }
        public Decimal codigo_tipo { get; set; }
        public String descripcion { get; set; }
        public bool habilitada { get; set; }
        public Decimal cantidadPersonas { get; set; }
        public Decimal precio { get; set; }

        public Habitacion()
        {
            identificador = -1;
        }

        public Habitacion(Decimal id, Decimal num, Decimal hotel, Decimal pis,
            Decimal tipo, String ubi, String desc, bool hab)
        {
            identificador = id;
            numero = num;
            codigo_hotel = hotel;
            piso = pis;
            ubicacion = ubi;
            codigo_tipo = tipo;
            descripcion = desc;
            habilitada = hab;
        }
    }
}
