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

namespace FrbaHotel.Login
{
    public partial class CambiarClave : Form
    {
        Decimal codigo_usuario;
        public CambiarClave(Decimal usu)
        {
            codigo_usuario = usu;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Claves Distintas", "Alerta", MessageBoxButtons.OK);
            }
            RepositorioUsuario.Instance.CambiarClave(codigo_usuario, textBox1.Text);

            MessageBox.Show("Clave cambiada con exito", "Alerta", MessageBoxButtons.OK);

            this.Close();
        }
    }
}
