using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.ABM_Rol
{
    public partial class ABMRol : Form
    {
        public ABMRol()
        {
            InitializeComponent();
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            new BajaModificacionRolWindow(ModoApertura.MODIFICACION).ShowDialog(this);
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            new BajaModificacionRolWindow(ModoApertura.BAJA).ShowDialog(this);
        }

        private void botonAlta_Click(object sender, EventArgs e)
        {
            new Alta().ShowDialog(this);
        }

        private void ABMRol_Load(object sender, EventArgs e)
        {

        }
    }
}
