using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    public class Estadia
    {
        public Decimal codigo { get; set; }
        public Decimal codigoReserva { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public Decimal precio { get; set; }
        public Decimal diasAlojados { get; set; }
        public Decimal diasNoAlojados { get; set; }

        public Estadia()
        {
            codigo = 0;
        }

        public Estadia(Decimal codigoEstadia, Decimal reservaCodigo, DateTime desde)
        {
            codigo = codigoEstadia;
            codigoReserva = reservaCodigo;
            fechaDesde = desde;
        }

        internal void CalcularDiasAlojados()
        {
            var anioHasta = fechaHasta.Year;
            var mesHasta = fechaHasta.Month;
            var diaHasta = fechaHasta.Day;
            var anioDesde = fechaDesde.Year;
            var mesDesde = fechaDesde.Month;
            var diaDesde = fechaDesde.Day;

            diasAlojados = (anioHasta - anioDesde) * 365 + (mesHasta - mesDesde) * 30 + diaHasta - diaDesde;
        }

        internal void CalcularDiasNoAlojados(DateTime dateTime)
        {
            if (fechaHasta.Date.CompareTo(dateTime.Date) == 0)
                diasNoAlojados = 0;
            else
            {
                var anioHasta = fechaHasta.Year;
                var mesHasta = fechaHasta.Month;
                var diaHasta = fechaHasta.Day;
                var anio = dateTime.Year;
                var mes = dateTime.Month;
                var dia = dateTime.Day;

                diasNoAlojados = (anio - anioHasta) * 365 + (mes - mesHasta) * 30 - diaHasta + dia;
            } 
        }
    }
}
