using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.LA_REVANCHA.Clases;
using FrbaHotel.LA_REVANCHA.Repositorios;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class BajaHab : Form
    {
        bool hab = false;
        bool des = false;
        Habitacion habitacion_seleccionada;

        public BajaHab(Habitacion hab)
        {
            habitacion_seleccionada = hab;
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
            int habilitar = 0;

            if (checkBoxdes.Checked)
            {
                habilitar = 0;
            }
            if (checkBoxhab.Checked)
            {
                habilitar = 1;
            }

            RepositorioHabitacion.Instance.BajarHab(habitacion_seleccionada.identificador, habilitar);


            MessageBox.Show("Se ha dado de baja exitosamente", "Alerta", MessageBoxButtons.OK);

            this.Close();
        }

        private void BajaHab_Load(object sender, EventArgs e)
        {
            var habitacion = RepositorioHabitacion.Instance.BuscarHab(habitacion_seleccionada.identificador);

            if (habitacion.habilitada == false)
            {
                checkBoxhab.Enabled = true;
                checkBoxdes.Enabled = false;
            }
            else
            {
                checkBoxdes.Enabled = true;
                checkBoxhab.Enabled = false;
            }
        }
    }
}
