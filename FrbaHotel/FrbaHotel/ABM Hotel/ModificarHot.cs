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

namespace FrbaHotel.ABM_Hotel
{
    public partial class ModificarHot : Form
    {
        bool cerrar = false;
        Hotel hotel_seleccionado;

        public ModificarHot(Hotel hot)
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

        private void ModificarHot_Load(object sender, EventArgs e)
        {
            textBoxcat.Text = hotel_seleccionado.categoria.ToString();
            textBoxciud.Text = hotel_seleccionado.ciudad;
            textBoxdir.Text = hotel_seleccionado.Calle;
            textBoxmail.Text = hotel_seleccionado.mail;
            textBoxnomb.Text = hotel_seleccionado.nombre;
            textBoxnrocal.Text = hotel_seleccionado.nro_calle.ToString();
            textBoxpa.Text = hotel_seleccionado.pais;
            textBoxtel.Text = hotel_seleccionado.telefono.ToString();

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
                Hotel bandera = RepositorioHotel.Instance.ExisteHotelMod(textBoxnomb.Text);
                if (bandera.identificador == hotel_seleccionado.identificador)
                {
                    Decimal recargo = Decimal.Parse(textBoxcat.Text) * 100;
                    RepositorioHotel.Instance.LimpiarHotelRegimen(hotel_seleccionado.identificador);
                    RepositorioHotel.Instance.ModificarHotel(Decimal.Parse(textBoxtel.Text),
                        Decimal.Parse(textBoxcat.Text), textBoxciud.Text, textBoxdir.Text,
                        textBoxnomb.Text, Decimal.Parse(textBoxnrocal.Text), textBoxpa.Text, recargo, hotel_seleccionado.identificador, textBoxmail.Text);

                    if (checkBoxall.Checked == true)
                    {
                        RepositorioHotel.Instance.ModificarHotelxRegimen(hotel_seleccionado.identificador, 1, 120);
                    }
                    else
                    {
                        RepositorioHotel.Instance.ModificarHotelxRegimen(hotel_seleccionado.identificador, 0, 120);
                    }
                    if (checkBoxdes.Checked == true)
                    {
                        RepositorioHotel.Instance.ModificarHotelxRegimen(hotel_seleccionado.identificador, 1, 110);
                    }
                    else
                    {
                        RepositorioHotel.Instance.ModificarHotelxRegimen(hotel_seleccionado.identificador, 0, 110);
                    }
                    if (checkBoxpc.Checked == true)
                    {
                        RepositorioHotel.Instance.ModificarHotelxRegimen(hotel_seleccionado.identificador, 1, 100);
                    }
                    else
                    {
                        RepositorioHotel.Instance.ModificarHotelxRegimen(hotel_seleccionado.identificador, 0, 100);
                    }
                    if (checkBoxallmod.Checked == true)
                    {
                        RepositorioHotel.Instance.ModificarHotelxRegimen(hotel_seleccionado.identificador, 1, 130);
                    }
                    else
                    {
                        RepositorioHotel.Instance.ModificarHotelxRegimen(hotel_seleccionado.identificador, 0, 130);
                    }

                    MessageBox.Show("Se ha modificado correctamente", "Alerta", MessageBoxButtons.OK);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("El nombre ya existe", "Alerta", MessageBoxButtons.OK);
                }
            }
        }

        private void textBoxnrocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }
    }
}
