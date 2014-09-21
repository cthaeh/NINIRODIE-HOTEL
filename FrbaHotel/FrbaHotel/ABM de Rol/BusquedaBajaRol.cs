using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class BusquedaBajaRol : Form
    {
        public BusquedaBajaRol()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxnom.Text == "")
            {
                MessageBox.Show("Ingrese un nombre de Rol", "ALERTA", MessageBoxButtons.OK);
            }
            else
            {
                //Se debe pasar el rol que se trae de la base.
                new BajaRol().ShowDialog(this);
            }
        }

    }
}
