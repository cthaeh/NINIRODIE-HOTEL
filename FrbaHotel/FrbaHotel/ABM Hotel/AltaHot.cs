using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Repositorios;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.ABM_Hotel
{
    public partial class AltaHot : Form
    {
        bool cerrar = false;
        int all = 0;
        int pen = 0;
        int solo = 0;

        public AltaHot()
        {
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

        private void textBoxnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxciud_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxcat_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxcat.Text == "" || textBoxciud.Text == "" || textBoxdir.Text == ""
                || textBoxmail.Text == "" || textBoxnomb.Text == "" || textBoxpa.Text == ""
                || textBoxtel.Text == "" || textBoxnrocal.Text == "")
            {
                MessageBox.Show("No deje campos vacios", "ALERTA", MessageBoxButtons.OK);
            }
            else if (decimal.Parse(textBoxcat.Text) < 1 || decimal.Parse(textBoxcat.Text) > 5)
            {
                MessageBox.Show("La categoria debe ser entre 1 y 5", "ALERTA", MessageBoxButtons.OK);
            }
            else
            {

                RepositorioHotel.Instance.InsertarHotel(Decimal.Parse(textBoxcat.Text), textBoxciud.Text,
                    textBoxdir.Text, textBoxnomb.Text, textBoxmail.Text, textBoxnrocal.Text,
                    textBoxpa.Text, Decimal.Parse(textBoxtel.Text), Decimal.Parse(textBoxnrocal.Text), dateTimePicker1.Value);

                Hotel hotel = RepositorioHotel.Instance.BuscarHotel(textBoxnomb.Text);

                if (checkBoxall.Checked == true)
                {
                    RepositorioHotel.Instance.InsertarHotelxRegimen(hotel.identificador, 100);
                }
                if (checkBoxdes.Checked == true)
                {
                    RepositorioHotel.Instance.InsertarHotelxRegimen(hotel.identificador, 101);
                }
                if (checkBoxpc.Checked == true)
                {
                    RepositorioHotel.Instance.InsertarHotelxRegimen(hotel.identificador, 102);
                }
            }
        }

        private void textBoxnrocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }
    }
}
