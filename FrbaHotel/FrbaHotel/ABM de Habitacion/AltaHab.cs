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
    public partial class AltaHab : Form
    {
        bool interna = false;
        bool externa = false;
        Hotel hotel_seleccionado;

        public AltaHab(Hotel hot)
        {
            hotel_seleccionado = hot;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Decimal cod_tipo = 0;

            if (textBoxnro.Text == "" || comboBoxtipos.Text == "" ||
                textBoxpis.Text == "" || textBoxdesc.Text == "")
            {
                MessageBox.Show("No deje campos vacios", "ALERTA", MessageBoxButtons.OK);
            }else if (decimal.Parse(textBoxnro.Text) < 1)
            {
                MessageBox.Show("El numero de habitacion debe ser mayor a 0", "ALERTA",
                    MessageBoxButtons.OK);
            }
            else if (decimal.Parse(textBoxpis.Text) < 1)
            {
                MessageBox.Show("El piso debe ser mayor a 0", "ALERTA",
                    MessageBoxButtons.OK);
            }
            else if (checkBoxext.Checked == false && checkBoxint.Checked == false)
            {
                MessageBox.Show("Seleccione una ubicacion", "ALERTA",
                    MessageBoxButtons.OK);
            }
            else
            {
                if (comboBoxtipos.Text == "Simple")
                {
                    cod_tipo = 1001;
                }
                else if (comboBoxtipos.Text == "Doble")
                {
                    cod_tipo = 1002;
                }
                else if (comboBoxtipos.Text == "Triple")
                {
                    cod_tipo = 1003;
                }
                else if (comboBoxtipos.Text == "Cuadruple")
                {
                    cod_tipo = 1004;
                }
                else { cod_tipo = 1005; }

                String ubi;
                if (checkBoxext.Checked == true)
                {
                    ubi = "externa";
                }
                else { ubi = "interna"; }

                Decimal bandera = RepositorioHabitacion.Instance.ExisteHab(hotel_seleccionado.identificador, Decimal.Parse(textBoxnro.Text));
                if (bandera == 2)
                {
                    RepositorioHabitacion.Instance.InsertarHabitacion(hotel_seleccionado.identificador,
                        Decimal.Parse(textBoxnro.Text), Decimal.Parse(textBoxpis.Text), textBoxdesc.Text, ubi, cod_tipo);

                    MessageBox.Show("Se ha dado de alta correctamente", "Alerta", MessageBoxButtons.OK);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ya existe ese numumero de habitacion", "Alerta", MessageBoxButtons.OK);
                }
            }
        }

        private void AltaHab_Load(object sender, EventArgs e)
        {
            //Cargas el combo box "tipos" con los tipos de habitacion
        }
    }
}
