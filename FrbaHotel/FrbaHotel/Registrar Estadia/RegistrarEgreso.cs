using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class RegistrarEgreso : Form
    {
        public Usuario usuario { get; set; }
        public Reserva reserva { get; set; }

        public RegistrarEgreso(Usuario user, Reserva reserv)
        {
            InitializeComponent();
            usuario = user;
            reserva = reserv;
        }
    }
}
