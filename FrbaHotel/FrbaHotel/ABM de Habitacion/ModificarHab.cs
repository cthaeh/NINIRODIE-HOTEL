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

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class ModificarHab : Form
    {
        bool interna = false;
        bool externa = false;
        Habitacion habitacion_seleccionada;
        Hotel hotel_seleccionado;

        public ModificarHab(Habitacion hab, Hotel hot)
        {
            hotel_seleccionado = hot;
            habitacion_seleccionada = hab;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void soloEscribeLetras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void soloEscribeNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxnro_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxpis_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxper_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void checkBoxext_CheckedChanged(object sender, EventArgs e)
        {
            if (externa == false)
            {
                externa = true;
                checkBoxint.Enabled = false;
                checkBoxext.Enabled = true;
            }
            else
            {
                externa = false;
                checkBoxint.Enabled = true;
            }
        }

        private void checkBoxint_CheckedChanged(object sender, EventArgs e)
        {
            if (interna == false)
            {
                interna = true;
                checkBoxext.Enabled = false;
                checkBoxint.Enabled = true;
            }
            else
            {
                interna = false;
                checkBoxext.Enabled = true;
            }
        }

        private void ModificarHab_Load(object sender, EventArgs e)
        {
            textBoxdesc.Text = habitacion_seleccionada.descripcion;
            textBoxnro.Text = habitacion_seleccionada.numero.ToString();
            textBoxpis.Text = habitacion_seleccionada.piso.ToString();

            if (habitacion_seleccionada.ubicacion == "externa")
            {
                checkBoxext.Enabled = false;
                checkBoxint.Enabled = true;
            }
            else
            {
                checkBoxint.Enabled = false;
                checkBoxext.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ubi = "";

            if (textBoxnro.Text == "" || textBoxpis.Text == "" || textBoxdesc.Text == "")
            {
                MessageBox.Show("No deje campos vacios", "ALERTA", MessageBoxButtons.OK);
            }
            else if (checkBoxext.Checked == false && checkBoxint.Checked == false)
            {
                MessageBox.Show("Seleccione una ubicacion", "ALERTA",
                    MessageBoxButtons.OK);
            }
            else
            {
                if(checkBoxext.Checked == true)
                {
                    ubi = "externa";
                }else
                {
                    ubi = "interna";
                }

                Habitacion bandera = RepositorioHabitacion.Instance.ExisteHabMod(hotel_seleccionado.identificador, Decimal.Parse(textBoxnro.Text));
                if (bandera.identificador == habitacion_seleccionada.identificador)
                {
                    RepositorioHabitacion.Instance.ModificarHabitacion(textBoxpis.Text, textBoxnro.Text, textBoxdesc.Text, ubi, habitacion_seleccionada.identificador);

                    MessageBox.Show("Se ha modificado Correctamente", "Alerta", MessageBoxButtons.OK);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ya existe habitacion con ese numero", "Alerta", MessageBoxButtons.OK);
                }
            }
        }
    }
}
