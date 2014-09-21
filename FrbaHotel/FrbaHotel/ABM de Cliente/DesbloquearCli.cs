using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class DesbloquearCli : Form
    {
        bool hab = false;
        bool des = false;

        public DesbloquearCli()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxhab_CheckedChanged(object sender, EventArgs e)
        {
            if (hab == false)
            {
                hab = true;
                checkBoxhab.Enabled = true;
                checkBoxdes.Enabled = false;
            }
            else
            {
                hab = false;
                checkBoxdes.Enabled = true;
            }
        }

        private void checkBoxdes_CheckedChanged(object sender, EventArgs e)
        {
            if (des == false)
            {
                des = true;
                checkBoxdes.Enabled = true;
                checkBoxhab.Enabled = false;
            }
            else
            {
                checkBoxhab.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se debe golpear la base bloqueado o desbloqueando el usuario
        }

        private void DesbloquearCli_Load(object sender, EventArgs e)
        {
            //Se debe setear los checkbox con los datos que estan en la base
        }
    }
}
