using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Empleado
{
    public partial class DesbloquearEmp : Form
    {
        bool hab = false;
        bool des = false;

        public DesbloquearEmp()
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
            //Golpear en la base bloqueando o desbloqueado el usuario
        }

        private void DesbloquearEmp_Load(object sender, EventArgs e)
        {
            //Setear los checkbox dependiendo de los datos de la base
        }
    }
}
