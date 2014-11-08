using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class ModificarReserva : Form
    {
        public Usuario usuario { get; set; }
        public Reserva reserva { get; set; }


        public ModificarReserva(Usuario user, Reserva reserve)
        {
            InitializeComponent();

        }
    }
}
