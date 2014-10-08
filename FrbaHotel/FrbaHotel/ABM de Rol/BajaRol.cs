using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.NINIRODIE.Repositorios;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class BajaRol : Form
    {
        bool hab = false;
        bool des = false;
        Rol rol_seleccionado;

        public BajaRol(Rol rol)
        {
            rol_seleccionado = rol;
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

        private void BajaRol_Load(object sender, EventArgs e)
        {
            if (rol_seleccionado.habilitado == true)
            {
                checkBoxdes.Enabled = true;
                checkBoxhab.Enabled = false;
            }
            else
            {
                checkBoxdes.Enabled = false;
                checkBoxhab.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hab;

            if (checkBoxdes.Enabled == true)
            {
                hab = 0;
            }
            else
            {
                hab = 1;
            }

            RepositorioRol.Instance.BajarRol(rol_seleccionado.identificador, hab);

            MessageBox.Show("Se ha dado de baja correctamente", "Alerta", MessageBoxButtons.OK);

            this.Close();
        }
    }
}
