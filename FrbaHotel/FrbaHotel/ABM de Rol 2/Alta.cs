using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.ABM_Rol;

namespace FrbaHotel.ABM_Rol
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void nuevoBoton_Click(object sender, EventArgs e)
        {
            new RolWindow(new Rol(), ModoApertura.GENERACION).ShowDialog(this);
        }

        private void existenteBoton_Click(object sender, EventArgs e)
        {
            new BajaModificacionRolWindow(ModoApertura.ALTA).ShowDialog(this);
        }
    }
}
