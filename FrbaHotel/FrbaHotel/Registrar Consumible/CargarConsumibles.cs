using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class CargarConsumibles : Form
    {
        Decimal reserva, personas, categoria, precio_base;
        public CargarConsumibles(Decimal res, Decimal per, Decimal cat, Decimal pr)
        {
            reserva = res;
            personas = per;
            categoria = cat;
            precio_base = pr;
            InitializeComponent();
        }
    }
}
