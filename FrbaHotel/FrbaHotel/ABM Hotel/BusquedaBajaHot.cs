using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_Hotel
{
    public partial class BusquedaBajaHot : Form
    {
        decimal banderacat = 0;
        bool seguir = false;

        public BusquedaBajaHot()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            banderacat = 0;
            if (textBoxcat.Text == "")
            {
                banderacat = 1000;
                seguir = true;
            }
            if (banderacat != 1000)
            {
                if (decimal.Parse(textBoxcat.Text) < 1 || decimal.Parse(textBoxcat.Text) > 5)
                {
                    MessageBox.Show("La categoria debe ser entre 1 y 5", "ALERTA", MessageBoxButtons.OK);
                    seguir = false;
                }
            }
            if (seguir == true)
            {
                new BajaHot().ShowDialog(this);
            }
        }
    }
}
