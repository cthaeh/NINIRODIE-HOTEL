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

namespace FrbaHotel.ABM_de_Empleado
{
    public partial class ModificarEmp : Form
    {
        Personal empleado_seleccionado;
        public ModificarEmp(Personal empleado)
        {
            empleado_seleccionado = empleado;
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

        private void textBoxnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxtel.Text == "" || textBoxnomb.Text == "" || textBoxmail.Text == ""
    || textBoxdni.Text == "" || textBoxdir.Text == "" || comboBox1.Text == ""
    || textBoxap.Text == "")
            {
                MessageBox.Show("No dejes campos vacios", "Alerta", MessageBoxButtons.OK);
            }
            else
            {
                Personal bandera = RepositorioEmpleado.Instance.ExisteEmpMod(Decimal.Parse(textBoxdni.Text));
                if (bandera.codigo_usuario == empleado_seleccionado.codigo_usuario || bandera.identificador == -1)
                {
                    RepositorioUsuario.Instance.ModificarEmp(empleado_seleccionado.codigo_usuario, comboBox1.Text);

                    RepositorioEmpleado.Instance.Modificar(textBoxap.Text, textBoxdir.Text,
                        Decimal.Parse(textBoxdni.Text), textBoxmail.Text, textBoxnomb.Text, Decimal.Parse(textBoxtel.Text), empleado_seleccionado.codigo_usuario);

                    MessageBox.Show("Modificacion Exitosa", "Alerta", MessageBoxButtons.OK);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("El documento ya existe", "Alerta", MessageBoxButtons.OK);
                }
            }
        }

        private void ModificarEmp_Load(object sender, EventArgs e)
        {
            List<Rol> roles = RepositorioRol.Instance.BuscarRoles();

            int n = 0;

            while (n < roles.Count)
            {
                comboBox1.Items.Add(roles.ElementAt(n).descripcion);
                n = n + 1;
            }

            var user = RepositorioEmpleado.Instance.BuscarEmpleadoXCod(empleado_seleccionado.identificador);
            var user_usu = RepositorioUsuario.Instance.BuscarUsuarioXCod(user.codigo_usuario);
            textBoxap.Text = user.apellido;
            textBoxnomb.Text = user.nombre;
            textBoxmail.Text = user.mail;
            textBoxtel.Text = user.telefono.ToString();
            textBoxdni.Text = user.numero_documento.ToString();
            textBoxdir.Text = user.direccion;
            comboBox1.Text = user_usu.tipo;
            
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

        private void textBoxmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }
    }
}
