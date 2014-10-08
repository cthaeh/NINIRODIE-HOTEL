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

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class AltaEmp : Form
    {
        bool salir = true;
        public AltaEmp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
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

        private void textBoxap_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxcla.Text != textBoxrepcla.Text)
            {
                MessageBox.Show("Claves Diferentes", "Alerta", MessageBoxButtons.OK);
            }
            if (textBoxrepcla.Text == "" || textBoxtel.Text == "" || textBoxnombusu.Text == ""
                || textBoxnomb.Text == "" || textBoxmail.Text == ""
                || textBoxdni.Text == "" || textBoxdir.Text == "" || textBoxcla.Text == "" || comboBox1.Text == ""
                || textBoxap.Text == "")
            {
                MessageBox.Show("No dejes campos vacios", "Alerta", MessageBoxButtons.OK);
                salir = false;
            }
            else
            {
                Decimal bandera = RepositorioEmpleado.Instance.ExisteEmp(Decimal.Parse(textBoxdni.Text));
                if (bandera == 2)
                {
                    Personal persona = new Personal(textBoxnomb.Text, textBoxap.Text,
                 "dni", Decimal.Parse(textBoxdni.Text), textBoxmail.Text, Decimal.Parse(textBoxtel.Text),
                 textBoxdir.Text, (dateTimePicker1.Value));

                    RepositorioUsuario.Instance.GenerarUsuario(textBoxcla.Text, textBoxnombusu.Text, comboBox1.Text);

                    Usuario usu = RepositorioUsuario.Instance.BuscarUsuario(textBoxnombusu.Text);

                    RepositorioEmpleado.Instance.GenerarEmpleado(persona, usu.codigo);

                    MessageBox.Show("Se ha dado de alta correctamente", "ALERTA", MessageBoxButtons.OK);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ya existe un empleado con ese documento", "Alerta", MessageBoxButtons.OK);
                }
            }
        }

        private void textBoxnrocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxpis_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxdep_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void AltaEmp_Load(object sender, EventArgs e)
        {
            List<Rol> roles = RepositorioRol.Instance.BuscarRoles();

            int n = 0;

            while (n < roles.Count)
            {
                comboBox1.Items.Add(roles.ElementAt(n).descripcion);
                n = n + 1;
            }
        }

    }
}
