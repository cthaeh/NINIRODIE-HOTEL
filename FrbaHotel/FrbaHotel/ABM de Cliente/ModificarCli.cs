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

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class ModificarCli : Form
    {
        Cliente cliente_seleccionado;

        public ModificarCli(Cliente cli)
        {
            cliente_seleccionado = cli;
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

        private void textBoxap_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxtipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxnro_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxdir_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxnac_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxcalle.Text == "" || textBoxdir.Text == "" || textBoxloc.Text == ""
    || textBoxmail.Text == "" || textBoxnac.Text == "" || textBoxnomb.Text == ""
    || textBoxnro.Text == "" || textBoxpa.Text == "" || textBoxtel.Text == ""
    || textBoxtipo.Text == "" || textBoxap.Text == "" || textBoxdep.Text == "" || textBoxpis.Text == "")
            {
                MessageBox.Show("No dejar campos vacios", "Alerta", MessageBoxButtons.OK);
            }
            else
            {
                Cliente bandera = RepositorioCliente.Instance.ExisteCliMod(Decimal.Parse(textBoxnro.Text));
                if (bandera.identificador == cliente_seleccionado.identificador)
                {
                    Cliente cli = new Cliente(textBoxnomb.Text, textBoxap.Text, textBoxtipo.Text, Decimal.Parse(textBoxnro.Text),
                        textBoxmail.Text, Decimal.Parse(textBoxtel.Text), textBoxcalle.Text, Decimal.Parse(textBoxdir.Text),
                        Decimal.Parse(textBoxpis.Text), textBoxdep.Text, (dateTimePicker1.Value),
                        textBoxloc.Text, textBoxpa.Text, textBoxnac.Text);

                    RepositorioCliente.Instance.ModificarCliente(cli, cliente_seleccionado.identificador);

                    MessageBox.Show("Se ha modificado Correctamente", "Alerta", MessageBoxButtons.OK);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ya existe un cliente con ese documento", "Alerta", MessageBoxButtons.OK);
                }
            }
        }

        private void ModificarCli_Load(object sender, EventArgs e)
        {
            textBoxap.Text = cliente_seleccionado.apellido;
            textBoxcalle.Text = cliente_seleccionado.calle;
            textBoxdep.Text = cliente_seleccionado.departamento;
            textBoxdir.Text = cliente_seleccionado.nro_calle.ToString();
            textBoxloc.Text = cliente_seleccionado.localidad;
            textBoxmail.Text = cliente_seleccionado.mail;
            textBoxnac.Text = cliente_seleccionado.nacionalidad;
            textBoxnomb.Text = cliente_seleccionado.nombre;
            textBoxnro.Text = cliente_seleccionado.numero_documento.ToString();
            textBoxpa.Text = cliente_seleccionado.pais;
            textBoxpis.Text = cliente_seleccionado.piso.ToString();
            textBoxtel.Text = cliente_seleccionado.telefono.ToString();
            textBoxtipo.Text = cliente_seleccionado.tipo_documento;
        }

        private void textBoxpis_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxdep_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }
    }
}
